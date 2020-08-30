using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleManagementSystem.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        [BindProperty]
        public Employee Employee { get; set; }
        
        [BindProperty] 
        public bool Notify { get; set; }
        public string Message { get; set; }
        //[DisplayName(displayName: "Photo")]
        [BindProperty]
        public List<IFormFile> Photo { get; set; }
        public EditModel(IEmployeeRepository employeeRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Employee = _employeeRepository.GetEmployeeById(id.Value);
            }
            else
            {
                Employee = new Employee();
            }
            if (Employee == null)
            {
                return RedirectToPage("/ErrorHandler/PageNotFound");
            }
            return Page();
        }
        public IActionResult OnPost(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (employee.PhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", employee.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    Employee.PhotoPath = ProcessUploadedFile();
                }
                if (Employee.Id > 0)
                {
                    Employee = _employeeRepository.UpdateEmployee(Employee);
                }
                else
                {
                    Employee = _employeeRepository.AddEmployee(Employee);
                }
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notification";
            }
            else
            {
                Message = "You have turned off email notification";
            }
            TempData["message"] = Message;
            return RedirectToPage("Details", new { id = id});
        }
       
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null && Photo.Count > 0)
            {
                foreach (IFormFile photo in Photo)
                {
                    string uploadedFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + " _ " + photo.FileName;
                    string filePath = Path.Combine(uploadedFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }


            }

            return uniqueFileName;
        }

      
    }
}
