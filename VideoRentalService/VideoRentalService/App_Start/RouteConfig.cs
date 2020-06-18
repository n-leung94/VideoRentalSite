using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VideoRentalService
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ORDER MATTERS SO ALWAYS PUT YOUR CUSTOM ROUTES BEFORE THE DEFAULT

            routes.MapMvcAttributeRoutes(); // To Enable Attribute Routing

            // Suppose we want movies/released/2015/04 I.E url shows movies released by date specified this is the old method, convention based routes.
            /*
            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new { controller = "Movies", action = "ByReleaseDate"},
                new {year = @"2015|2016", month = @"\d{2}"}  // Force constraint to 2015 and 2016 and 2 digit month
                );
            */

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
