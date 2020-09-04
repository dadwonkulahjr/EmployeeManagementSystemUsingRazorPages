using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;
using EmployeeManagement.Services;

namespace SimpleManagementSystem
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeManagement.Services.CustomDataAccess _context;

        public IndexModel(EmployeeManagement.Services.CustomDataAccess context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees.ToListAsync();
        }
    }
}
