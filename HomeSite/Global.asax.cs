using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HomeSite.Infrastructure;
using System.Data.Entity;
using HomeSite.Models;
using HomeSite.DataBase;

namespace HomeSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectFactory());
            //Database.SetInitializer<MyContext>(new MyInitializer());
        }
    }
}
