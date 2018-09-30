using LearningMVC.Migrations;
using System.Data.Entity.Migrations;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiContrib.Formatting.Jsonp;
using WebMatrix.WebData;

namespace LearningMVC
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //Tells when migrations to run
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();

            //Only initialise when nnot already initialised.
            if (!WebSecurity.Initialized) { WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Users", "ID", "Username", true); }

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);  
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Can enable CORS in web API 2.

            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());

            //JsonP for cross origin (wraps JSON call in object)
            var jsonPFormatter = new JsonpMediaTypeFormatter(GlobalConfiguration.Configuration.Formatters[0], "callback");// jsonp callsback to callback
            GlobalConfiguration.Configuration.Formatters.Insert(0, jsonPFormatter); //Insertred so this is hit first.

            //Authentication "who" (User name and Password).
            //Authorisation "rights" (What the authenticated person can do).
            //Can use OAuth or Forms for this.
        }
    } 
}
