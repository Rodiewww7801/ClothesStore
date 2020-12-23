using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ClothesStore.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "",
                new
                {
                    controller = "Home",
                    action = "List",
                    category = (string)null,
                }
            );

            routes.MapRoute(null,
                "{category}",
                new { controller = "Home", action = "List" }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
