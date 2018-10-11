using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

//using MultipartDataMediaFormatter;
//using MultipartDataMediaFormatter.Infrastructure;

namespace Mdia.WebAPI
{
    public class Global : HttpApplication
    {
        // Code that runs on application startup
        void Application_Start(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = int.MaxValue; //connectionManagement/maxconnection limit

            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            

            


        }



    }
}