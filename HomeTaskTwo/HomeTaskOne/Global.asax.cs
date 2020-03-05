using Autofac;

using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;
using System.Data.Entity;

using HomeTaskOne.Data;

namespace HomeTaskOne
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            DI.Init();
        }
    }
}
