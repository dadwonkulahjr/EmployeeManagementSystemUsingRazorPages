using EmployeeManagement.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace EmployeeManagement.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetListOfEmployees();
        Employee GetEmployeeById(int id);
        Employee UpdateEmployee(Employee employeechanges);

    }
}
