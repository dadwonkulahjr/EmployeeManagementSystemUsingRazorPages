using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleManagementSystem.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        public Employee Employee { get; set; }
        [DisplayName(displayName: "Photo")]
        public IFormFile CustomPhoto{ get; set; }
        public EditModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployeeById(id);
        }
        public IActionResult OnPost(Employee employee)
        {
            Employee = _employeeRepository.UpdateEmployee(employee);
            if(Employee == null)
            {
                return RedirectToPage("PageNotFound");
            }
            return RedirectToPage("Index");
        }
    }
}
