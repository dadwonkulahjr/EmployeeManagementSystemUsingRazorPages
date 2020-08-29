using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is mandatory!")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Email is mandatory!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Department is mandatory!")]
        public Department? Department { get; set; }
        [Display(Name ="Image")]
        public string PhotoPath { get; set; }

    }
}
