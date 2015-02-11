using System.Web.Mvc;
using System.Web.Routing;

namespace MvcPattern.App_Start
{
    public class Router
    {
        /// <summary>
        /// Method to register routes which maps the requested URL to some Action in a Controller
        /// </summary>
        /// <param name="routes">Collection of Routes</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Student",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }

    }
}