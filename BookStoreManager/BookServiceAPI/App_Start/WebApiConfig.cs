using BookServiceAPIClient.Formatters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookServiceAPIClient.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.Formatters.Insert(0, new JsonpFormatter());

            // Enable CORS support - requires Microsoft ASP.NET Web API 2.1 Cross-Origin Support package
            var cors = new EnableCorsAttribute(ConfigurationManager.AppSettings["origins"], "*", "*");
            config.EnableCors();
        }
    }
}