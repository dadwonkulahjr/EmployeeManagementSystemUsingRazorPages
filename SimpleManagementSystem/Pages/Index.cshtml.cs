using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SimpleManagementSystem.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public IndexModel()
        {
           
        }

        public void OnGet()
        {
            Message = "The time check in the city of monrovia is " + DateTime.Now.ToLongTimeString();
        }
    }
}
