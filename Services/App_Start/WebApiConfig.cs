using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Services.Common;
namespace Services
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithAction",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ActionWithoutParameter",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = "Index" }
            );

            //#region Routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiWithAction",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { action = "Index", id = RouteParameter.Optional }
            //);
            //config.Routes.MapHttpRoute(
            //    name: "ActionWithoutParameter",
            //    routeTemplate: "api/{controller}/{action}",
            //    defaults: new { action = "Index" }
            //);
            //#endregion

            //#region Filters
            //config.Filters.Add(new ExceptionFilters());
            //#endregion



        }
    }
}
