using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BusinessAPISQL
{
    public static class WebApiConfig
    {
        public static void Register1(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
