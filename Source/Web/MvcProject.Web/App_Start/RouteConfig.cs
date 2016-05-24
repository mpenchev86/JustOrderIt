﻿namespace MvcProject.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //// TEST - route constraints
            // routes.MapRoute(
            //    name: "ProductsList",
            //    url: "Products/{page}/{nonNullableInt}",
            //    defaults: new
            //    {
            //        controller = "Home",
            //        action = "ProductsList",
            //        page = UrlParameter.Optional,
            //        nonNullableInt = UrlParameter.Optional
            //    },
            //    constraints: new
            //    {
            //        page = @"\d{3,}",
            //        nonNullableInt = @"\d+",
            //        isChrome = new CustomRouteConstraints()
            //    });

            //// MvcRouteTester doesn't work if this route is defined in the area registration
            //routes
            //    .MapRoute(
            //        name: "ProductPage",
            //        url: "Product/{id}",
            //        defaults: new { controller = "Products", action = "ById" })
            //    .DataTokens.Add("area", "Common");

            //routes
            //    .MapRoute(
            //        name: "Default",
            //        url: "{controller}/{action}/{id}",
            //        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional })
            //    .DataTokens.Add("area", "Common");

            //routes
            //    .MapRoute(
            //        name: "Default",
            //        url: "{controller}/{action}",
            //        defaults: new { controller = "Products", action = "Index"},
            //        namespaces: new string[] { "MvcProject.Web.Controllers.ProductsController" });
        }

        // TEST - route constraints
        private class CustomRouteConstraints : IRouteConstraint
        {
            public bool Match(
                HttpContextBase httpContext,
                Route route,
                string parameterName,
                RouteValueDictionary values,
                RouteDirection routeDirection)
            {
                return HttpContext.Current.Request.UserAgent.Contains("Chrome");
            }
        }
    }
}
