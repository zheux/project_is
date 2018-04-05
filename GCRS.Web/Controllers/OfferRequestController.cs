using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCRS.Web.Controllers
{
    public class OfferRequestController : Controller
    {
        public OfferRequestController()
        {

        }

        // GET: OfferRequest/CreateRequest
        public ActionResult CreateRequest()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateRequest(int x, int y)
        {
            //TODO: Recoger la ubicacion de la propiedad que manda el mapa y crear el Request
            return RedirectToAction("Index", "Home");
        }
    }
}
