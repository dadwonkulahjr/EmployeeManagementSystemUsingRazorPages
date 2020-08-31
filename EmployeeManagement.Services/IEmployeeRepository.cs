using EmployeeManagement.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace EmployeeManagement.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> SearchForEmployee(string searchTerm);
        IEnumerable<Employee> GetListOfEmployees();
        Employee GetEmployeeById(int id);
        Employee UpdateEmployee(Employee employeechanges);
        Employee AddEmployee(Employee newEmployee);
        Employee Delete(int id);
        IEnumerable<DeptHeadCount> EmployeeCountByDepartment(Department? dept);
    }
}
