using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory!"), MinLength(8, ErrorMessage = "Name can only contain 4 characters!")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage ="Email has some invalid characters")]
        [EmailAddress(ErrorMessage ="Email is mandatory!")]
        public string Email { get; set; }
        [Required]
        public Department? Department { get; set; }
        [Display(Name ="Image")]
        public string PhotoPath { get; set; }

    }
}
