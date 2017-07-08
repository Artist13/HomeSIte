using System;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeSite.DataBase;

namespace HomeSite.Models.Auth
{
    public class UserIdentity : IIdentity
    {
        public Admin Admin { get; set; }
        public string AuthenticationType
        {
            get
            {
                return typeof(Admin).ToString();
            }
        }
        public bool IsAuthenticated
        {
            get
            {
                return Admin != null;
            }
        }
        public string Name
        {
            get
            {
                if(Admin != null)
                {
                    return Admin.Login;
                }
                return "anonym";
            }
        }
        public void Init(string login, MyDataBase db )
        {
            if (!string.IsNullOrEmpty(login))
            {
                Admin = db.Admins.FirstOrDefault(x => x.Login == login );
            }
        }
    }
}