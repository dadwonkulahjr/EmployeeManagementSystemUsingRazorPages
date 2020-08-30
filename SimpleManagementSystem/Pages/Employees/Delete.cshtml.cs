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
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        [BindProperty]
        public Employee Employee { get; set; }
        public DeleteModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployeeById(id);
            if (Employee == null)
            {
                return RedirectToPage("/ErrorHandler/PageNotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Employee = _employeeRepository.Delete(Employee.Id);
            if (Employee == null)
            {
                return RedirectToPage("/ErrorHandler/PageNotFound");
            }
            return RedirectToPage("Index");
        }
    }
}
