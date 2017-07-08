using System;
using System.Security;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeSite.DataBase;

namespace HomeSite.Models.Auth
{
    public class UserProvider : IPrincipal
    {
        private UserIdentity userIdentity { get; set; }

        public IIdentity Identity
        {
            get
            {
                return userIdentity;
            }
        }
        public bool IsInRole(string role)
        {
            if (userIdentity.Admin == null)
            {
                return false;
            }
            return userIdentity.Admin.InRole(role);
        }
        public UserProvider(string name, MyDataBase db)
        {
            userIdentity = new UserIdentity();
            userIdentity.Init(name, db);
        }
        public override string ToString()
        {
            return userIdentity.Name;
        }
    }
}