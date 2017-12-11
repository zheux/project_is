using GCRS.Maps.Core;
using System.Configuration;
using System.Web.Mvc;

namespace GCRS.Web.Controllers
{
    public class MapController : Controller
    {
        private readonly string mapFolder = ConfigurationManager.AppSettings["CubaMapFolder"];

        // GET: Map
        public ActionResult Index()
        {
            var mapHandler = new CubaMapHandler(Server.MapPath(mapFolder));

            var url = Request.Url.AbsoluteUri;
            if (Request.Url.Query.Length > 0)
            {
                url = url.Replace(Request.Url.Query, string.Empty);
            }
            mapHandler.ProcessRequest(url);

            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult GetRoute(double startX, double startY, double endX, double endY)
        {
            var pbfFile = Server.MapPath($"{mapFolder}/{ConfigurationManager.AppSettings["PbfFile"]}");
            var routeDbFile = Server.MapPath($"{mapFolder}/{ConfigurationManager.AppSettings["RouteDbFile"]}");
            var routingService = new RouteService(pbfFile, routeDbFile);

            return Json(routingService.GetRoute(startX, startY, endX, endY), JsonRequestBehavior.AllowGet);
        }
    }
}