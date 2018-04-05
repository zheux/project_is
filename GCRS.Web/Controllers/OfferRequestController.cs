using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;
using GCRS.Services;

namespace GCRS.Web.Controllers
{
    public class OfferRequestController : Controller
    {
        private IUnitOfWork unitOfWork;
        private OfferRequestingService requestService;
        
        public OfferRequestController(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
            requestService = new OfferRequestingService();
        }

        // GET: Account/OfferRequests
        //[Authorize(Roles = "agent")]
        public ActionResult Index()
        {
            return View(unitOfWork.Repository<OfferRequest>().Where(o => !o.isDeleted)
                                                             .Where(o => o.AgentUsername == HttpContext.User.Identity.Name)
                                                             .ToList());
        }


        // GET: OfferRequest/CreateRequest
        //[Authorize(Roles = "client")]
        public ActionResult CreateRequest()
        {
            return View();
        }
        

        //[Authorize(Roles = "client")]
        [HttpPost]
        public ActionResult CreateRequest(int? x, int? y)
        {
            //TODO: Recoger la ubicacion de la propiedad que manda el mapa y crear el Request
            requestService.MakeRequest(unitOfWork.Repository<Client>().SingleOrDefault(c => c.Username == HttpContext.User.Identity.Name));
            return RedirectToAction("Index", "Home");
        }


        // POST: Account/AcceptRequest/id
        //[Authorize(Roles = "agent")]
        public ActionResult AcceptRequest(int id)
        {
            OfferRequest Request = unitOfWork.Repository<OfferRequest>()
                                                    .Include("Client")
                                                    .Include("Agent")
                                                    .SingleOrDefault(o => o.Id == id);
            Agent curAgent = unitOfWork.Repository<Agent>().SingleOrDefault(a => a.Username == HttpContext.User.Identity.Name);
            if (Request == null)
                throw new Exception("La solicitud " + id.ToString() + " no existe !");
            if(curAgent.Username == Request.AgentUsername)
                requestService.AcceptRequest(curAgent, Request.Client);
            return RedirectToAction("Index");
        }


        // POST: Account/RemoveRequest/id
        //[Authorize(Roles = "agent")]
        public ActionResult RemoveRequest(int id)
        {
            OfferRequest Request = unitOfWork.Repository<OfferRequest>()
                                                    .Include("Client")
                                                    .Include("Agent")
                                                    .SingleOrDefault(o => o.Id == id);
            if (Request == null)
                throw new Exception("La solicitud " + id.ToString() + " no existe !");
            if(HttpContext.User.Identity.Name == Request.AgentUsername)
                requestService.RemoveRequest(Request.Client);
            return RedirectToAction("Index");
        }
    }
}
