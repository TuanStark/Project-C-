using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cake_shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CategoryProduct",
                url: "san-pham",
                defaults: new { controller = "Products", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "Cake_shop.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "Cake_shop.Controllers" }
            );

            routes.MapRoute(
                name: "detailProduct",
                url: "chi-tiet/{alias}-{id}",
                defaults: new { controller = "Products", action = "ProductsDetails", id = UrlParameter.Optional },
                namespaces: new[] { "Cake_shop.Controllers" }
           );
            
        }
    }
}
