using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoutingMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            #region Traditional Routing
            //routes.MapRoute(
            //    name: "GetAllStudents",
            //    url: "students/{action}",
            //    defaults: new { controller = "Student", actiion = "Index" }
            //);

            //routes.MapRoute(
            //    name: "GetStudent",
            //    url: "students/{id}",
            //    defaults: new {Controller = "Student", Action = "GetStudent" }
            //);

            //routes.MapRoute(
            //    name: "GetAddress",
            //    url: "students/address/{id}",
            //    defaults: new { Controller = "Student", Action = "GetAddress" }
            //);

            //routes.MapRoute(
            //    name: "GetAllAdd",
            //    url: "students/address",
            //    defaults: new { Controller = "Student", Action = "GetAllAddress" }
            //);
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
