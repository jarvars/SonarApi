using System.Web.Mvc;
using System.Web.Routing;

namespace SonarApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Metric",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Metric", action = "Metrics", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "User",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Users", id = UrlParameter.Optional }
            );
            
        }
    }
}
