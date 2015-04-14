using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lesson4
{
    public class RouteConfig
    {
        /* route data - хеш коллекция*/ 
        public static void RegisterRoutes(RouteCollection routes) //RouteCollectoin
            
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Products", action = "Index"}
            );

            routes.MapRoute(
                name: "Product",
                url: "Product/{code}",
                defaults: new { controller = "Products", action = "Product", code = "FF-001" },
                constraints: new { code = @"[A-Z,a-z]{2}\-[0-9]{3}" }
            );

            routes.MapRoute(
                name: "PrintProduct",
                url: "Product/{code}/Print", 
                defaults: new { controller = "Products", action = "PrintProduct", code = "FF-001" },
                constraints: new { code = @"[A-Z,a-z]{2}\-[0-9]{3}" }
            );

            routes.MapRoute(
                name: "ShowCats",
                url: "Products/{cat}/{page}", 
                defaults: new { controller = "Products", action = "ShowByCats", cat = "Food", page = 1 },
                constraints: new { cat = new CatRouteConstraint(), page = @"\d+" }
            );

            routes.MapRoute(
                name: "ShowByDate",
                url: "Products/date/{date}/{page}", 
                defaults: new { controller = "Products", action = "ShowByDate", date= "2000-01-01", page=1 },
                constraints: new {date = new DateConstraint(), page = @"\d+"} //добавим экземпляр нашего констрэйнта для фильтрации введеной даты. 
            );
            
        }
    }
}
