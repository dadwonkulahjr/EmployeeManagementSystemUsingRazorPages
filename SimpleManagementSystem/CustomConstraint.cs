using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleManagementSystem.Pages.Employees
{
    public class CustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            int result = 0;
            if (int.TryParse(values["id"].ToString(), out result))
            {
                if(result % 2  == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
