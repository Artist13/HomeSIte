using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace HomeSite.Models.Auth
{
    interface IAuthentication
    {
        HttpContext HttpContext { get; set; }

        Admin Login(string login, string password, bool isPersistent);

        
        void LogOut();

        IPrincipal CurrentUser { get; }
    }
}
