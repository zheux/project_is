using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GCRS.Web
{
    public partial class Startup
    {
        public void ConfigureRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        public void ConfigureFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public void ConfigureBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/node_modules/jquery/dist/jquery.min.js",
                        "~/node_modules/popper.js/dist/umd/popper.min.js",
                        "~/node_modules/bootstrap/dist/js/bootstrap.min.js",
                        "~/wwwroot/app.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/node_modules/bootstrap/dist/css/bootstrap.css",
                      "~/node_modules/ol/ol.css",
                      "~/Content/app.css"));
        }
    }
}