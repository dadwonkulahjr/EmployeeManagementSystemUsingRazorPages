using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleManagementSystem.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IndexModel(IEmployeeRepository employeeRepository)
        {
           _employeeRepository = employeeRepository;
        }
        public void OnGet()
        {
            Employees = _employeeRepository.SearchForEmployee(SearchTerm);
        }
    }
}
