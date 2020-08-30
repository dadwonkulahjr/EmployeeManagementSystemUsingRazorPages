using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagement.Services
{
    public class CustomEmployeeImplementation : IEmployeeRepository
    {
        private readonly List<Employee> _employeeList;
        public CustomEmployeeImplementation()
        {
            _employeeList = new List<Employee>()
           {
               new Employee(){Id=1, Name="Mary", Department = Department.HR, Email="mary@gmail.com", PhotoPath="carousel 6.jpg"},
               new Employee(){Id=2, Name="Mike", Department = Department.IT, Email="mike@outlook.com", PhotoPath="carousel 14.jpg"},
               new Employee(){Id=3, Name="Sara", Department = Department.HR, Email="sara@hotmail.com", PhotoPath="carousel 12.jpg"},
               new Employee(){Id=4, Name="Sam", Department = Department.IT, Email="sam@yahoo.com", PhotoPath="carousel 1.jpg"},
               new Employee(){Id=5, Name="Don Jones", Department = Department.Management, Email="donjones@gmail.com" }
           };
        }

        public Employee AddEmployee(Employee newEmployee)
        {
            newEmployee.Id = _employeeList.Max(emp => emp.Id) + 1;
            _employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
           Employee employee = _employeeList.FirstOrDefault(emp => emp.Id == id);
            if(employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(emp => emp.Id == id);
            return employee;
        }

        public IEnumerable<Employee> GetListOfEmployees()
        {
            return _employeeList;
        }

        public Employee UpdateEmployee(Employee employeechanges)
        {
            Employee employee = _employeeList.FirstOrDefault(emp => emp.Id == employeechanges.Id);
            if(employee != null)
            {
                employee.Name = employeechanges.Name;
                employee.Email = employeechanges.Email;
                employee.Department = employeechanges.Department;
                employee.PhotoPath = employeechanges.PhotoPath;
            }
            return employee;
          
        }
    }
}
