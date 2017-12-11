using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(GCRS.Web.Startup))]
namespace GCRS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureBundles(BundleTable.Bundles);
            ConfigureFilters(GlobalFilters.Filters);
            ConfigureRoutes(RouteTable.Routes);
        }
    }
}