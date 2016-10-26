using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace PatStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("PatStore", "User", "Id", "Email", true);

            //Creates admin role if it does not exist
            //if (Roles.RoleExists("Administrator"))
                //Roles.CreateRole("Administrator");
        }
    }
}
