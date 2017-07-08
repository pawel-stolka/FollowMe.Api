using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace FollowMe.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{api}/{controller}/{id}",
                defaults: new { api = "api", controller = "categories", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ApiByAction",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { api = "api", controller = "categories", action = "Get" }
            );

            config.Routes.MapHttpRoute(
                name: "ApiByDateTime",
                routeTemplate: "api/{controller}/{action}/{name}/{datetime}",
                defaults: new { api = "api", controller = "session", action = "get", datetime = RouteParameter.Optional }
                //constraints: new { name = @"^[a-z] + $"}
            );
        }
    }
}
