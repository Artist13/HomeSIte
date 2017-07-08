using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using HomeSite.Models.Auth;
using HomeSite.DataBase;    

namespace HomeSite.Models.Auth
{
    public class CustomAuthentication : IAuthentication
    {
        private const string cookieName = "__AUTH_COOKIE";
        public MyDataBase db = new MyDataBase();
        public HttpContext HttpContext { get; set; }

        public Admin Login(string login, string password, bool isPersistent)
        {
            HttpContext = HttpContext.Current;
            Admin tempAdmin = db.Admins.FirstOrDefault(x => (string.Compare(x.Login, login, true) == 0));
            if (tempAdmin != null && tempAdmin.Pass == password)
            {
                CreateCookie(login, isPersistent);
            }
            return tempAdmin;
        }
        
        public void CreateCookie(string login, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(1, login, DateTime.Now, DateTime.Now.Add(FormsAuthentication.Timeout), isPersistent, string.Empty, FormsAuthentication.FormsCookiePath);

            var encryptTicket = FormsAuthentication.Encrypt(ticket);

            HttpCookie AuthCookie = new HttpCookie(cookieName)
            {
                Value = encryptTicket
            };
            //AuthCookie.Expires = DateTime.Now.Add(new TimeSpan(0, 0, 15, 10));
            HttpContext.Response.Cookies.Set(AuthCookie);
        }

        public void LogOut()
        {
            HttpContext = HttpContext.Current;
            var httpCookie = HttpContext.Response.Cookies[cookieName];
            if(httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }

        private Admin _currentAdmin;
        public Admin CurrentAdmin
        {
            get
            {
                if(_currentAdmin == null)
                {
                    try
                    {
                        HttpCookie authCookie = HttpContext.Request.Cookies.Get(cookieName);
                        if(authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            _currentAdmin = db.Admins.FirstOrDefault(x => x.Login == ticket.Name);
                        }
                        else
                        {
                            _currentAdmin = new Admin();
                        }
                    }
                    catch(Exception ex)
                    {
                        _currentAdmin = new Admin();
                    }
                }
                return _currentAdmin;
            }
        }
        public IPrincipal CurrentUser
        {
            get
            {
                return new UserProvider(null, null);
            }
        }
            
    }
}