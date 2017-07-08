using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeSite.Models
{
    public class Admin
    {
        public int adminId { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Role { get; set; }
        public bool InRole(string role)
        {
            if(role == Role)
            {
                return true;
            }
            return false;
        }
    }
}