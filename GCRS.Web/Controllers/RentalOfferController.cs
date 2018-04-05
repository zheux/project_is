using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;
using GCRS.Web.ViewModels;

namespace GCRS.Web.Controllers
{
    public class RentalOfferController : Controller
    {
        private IAgentRepository _agentRepo;
        private IClientRepository _clientRepo;
        private IPropertyRepository _propertyRepo;
        private ITagRepository _tagRepo;
        private IRentTimeUnitRepository _rtuRepo;
        private IOfferRepository<RentalOffer> _RentalOfferRepo;
        
        public RentalOfferController(IOfferRepository<RentalOffer> RentalOfferRepository, IAgentRepository agentRepo,
            IClientRepository clientRepo, IPropertyRepository propertyRepo, ITagRepository tagRepo, IRentTimeUnitRepository rtuRepo)
        {
            _RentalOfferRepo = RentalOfferRepository;
            _agentRepo = agentRepo;
            _clientRepo = clientRepo;
            _propertyRepo = propertyRepo;
            _tagRepo = tagRepo;
            _rtuRepo = rtuRepo;

        }

        // GET: Properties
        public ActionResult Index()
        {
            return View(_RentalOfferRepo.GetOffers());
        }



        // GET: AddRentalOffer
        public ActionResult AddRentalOffer()
        {
            return View(new RentalOfferViewModels {
                Offer = new RentalOffer(),
                Agents = _agentRepo.GetAgents(),
                Clients = _clientRepo.GetClients(),
                Properties = _propertyRepo.GetProperties(),
                Tags = _tagRepo.GetTags(),
                RTU = _rtuRepo.GetRentTimeUnits()
            });
        }

        // POST: AddRentalOffer
        [HttpPost]
        public ActionResult AddRentalOffer(RentalOffer Offer)
        {
            if (Offer.Title == null)
                ModelState.AddModelError("Offer.Title", "Hay que poner un titulo!");
            if (Offer.ClientUserName == null)
                ModelState.AddModelError("Offer.ClientUserName", "Hay que escoger un cliente!");
            if (Offer.PropertyId == 0)
                ModelState.AddModelError("Offer.PropertyId", "Hay que escoger una propiedad!");

            if (!ModelState.IsValid)
                return View(new RentalOfferViewModels
                {
                    Offer = new RentalOffer(),
                    Agents = _agentRepo.GetAgents(),
                    Clients = _clientRepo.GetClients(),
                    Properties = _propertyRepo.GetProperties(),
                    Tags = _tagRepo.GetTags(),
                    RTU = _rtuRepo.GetRentTimeUnits()
                });

            _RentalOfferRepo.AddOffer(new Domain.RentalOffer() { Agent = Offer.Agent, Tags = Offer.Tags, PropertyId = Offer.PropertyId,
                                ClientUserName = Offer.ClientUserName, Comission = 100, Description = Offer.Description, PricePerRTU = Offer.PricePerRTU,
                                State = OfferState.Published, Title = Offer.Title, RTU = _rtuRepo.FindRentTimeUnit(m => m.Name == "Noche")});
            return RedirectToAction("Index");
        }


        // GET: /Delete/RentalOffer
        public ActionResult Delete(int id)
        {
            _RentalOfferRepo.RemoveOffer(id);
            return RedirectToAction("Index");
        }
    }
}
