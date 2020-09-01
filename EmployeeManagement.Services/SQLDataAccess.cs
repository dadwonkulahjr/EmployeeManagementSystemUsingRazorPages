using EmployeeManagement.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagement.Services
{
    public class SQLDataAccess : IEmployeeRepository
    {
        private readonly CustomDataAccess _customDataAccess;

        public SQLDataAccess(CustomDataAccess customDataAccess)
        {
            _customDataAccess = customDataAccess;
        }
        public Employee AddEmployee(Employee newEmployee)
        {
            _customDataAccess.Database.ExecuteSqlRaw("sp_AddNewEmployee {0}, {1}, {2}, {3}",
                newEmployee.Name,
                newEmployee.Email,
                newEmployee.Department,
                newEmployee.PhotoPath);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _customDataAccess.Employees.Find(id);
            if(employee != null)
            {
                _customDataAccess.Employees.Remove(employee);
                _customDataAccess.SaveChanges();
            }

            return employee;

        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDepartment(Department? dept)
        {
            IEnumerable<Employee> query = _customDataAccess.Employees;
            if (dept.HasValue)
            {
                query = query.Where(emp => emp.Department == dept.Value);
            }
            return query.GroupBy((emp) => emp.Department)
                                         .Select((g) => new DeptHeadCount()
                                         {
                                             Department = g.Key.Value,
                                             Count = g.Count()
                                         }).ToList();
           
        }

        public Employee GetEmployeeById(int id)
        {
            SqlParameter sqlParameter = new SqlParameter("@Id", id);
            return _customDataAccess.Employees.FromSqlRaw<Employee>
                ("sp_GetEmployeeById @Id", sqlParameter).ToList().FirstOrDefault();
        }

        public IEnumerable<Employee> GetListOfEmployees()
        {
            return _customDataAccess.Employees.FromSqlRaw("Select * From Employees");
        }

        public IEnumerable<Employee> SearchForEmployee(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _customDataAccess.Employees;
            }
            return _customDataAccess.Employees.Where(emp => emp.Name.Contains(searchTerm)
                    || emp.Email.Contains(searchTerm));
        }

        public Employee UpdateEmployee(Employee employeechanges)
        {
            var result = _customDataAccess.Employees.Attach(employeechanges);
            result.State = EntityState.Modified;
            _customDataAccess.SaveChanges();
            return employeechanges;
           
               
        }
    }
}
