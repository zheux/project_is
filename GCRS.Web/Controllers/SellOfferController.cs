using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;
using GCRS.Web.ViewModels;

namespace GCRS.Web.Controllers
{
    public class SellOfferController : Controller
    {
        private IAgentRepository _agentRepo;
        private IClientRepository _clientRepo;
        private IPropertyRepository _propertyRepo;
        private ITagRepository _tagRepo;
        private IOfferRepository<SellOffer> _SellOfferRepo;
        
        public SellOfferController(IOfferRepository<SellOffer> SellOfferRepository, IAgentRepository agentRepo,
            IClientRepository clientRepo, IPropertyRepository propertyRepo, ITagRepository tagRepo)
        {
            _SellOfferRepo = SellOfferRepository;
            _agentRepo = agentRepo;
            _clientRepo = clientRepo;
            _propertyRepo = propertyRepo;
            _tagRepo = tagRepo;

        }

        // GET: Properties
        public ActionResult Index()
        {
            return View(_SellOfferRepo.GetOffers());
        }



        // GET: AddSellOffer
        public ActionResult AddSellOffer()
        {
            return View(new SellOfferViewModels {
                Offer = new SellOffer(),
                Agents = _agentRepo.GetAgents(),
                Clients = _clientRepo.GetClients(),
                Properties = _propertyRepo.GetProperties(),
                Tags = _tagRepo.GetTags()
            });
        }

        // POST: AddSellOffer
        [HttpPost]
        public ActionResult AddSellOffer(SellOffer Offer)
        {
            if (Offer.Title == null)
                ModelState.AddModelError("Offer.Title", "Hay que poner un titulo!");
            if (Offer.ClientUserName == null)
                ModelState.AddModelError("Offer.ClientUserName", "Hay que escoger un cliente!");
            if (Offer.PropertyId == 0)
                ModelState.AddModelError("Offer.PropertyId", "Hay que escoger una propiedad!");

            if (!ModelState.IsValid)
                return View(new SellOfferViewModels
                {
                    Offer = new SellOffer(),
                    Agents = _agentRepo.GetAgents(),
                    Clients = _clientRepo.GetClients(),
                    Properties = _propertyRepo.GetProperties(),
                    Tags = _tagRepo.GetTags()
                });

            _SellOfferRepo.AddOffer(new Domain.SellOffer() { Agent = Offer.Agent, Tags = Offer.Tags, PropertyId = Offer.PropertyId,
                                ClientUserName = Offer.ClientUserName, Comission = 100, Description = Offer.Description, Price = Offer.Price,
                                State = State.Published, Title = Offer.Title});
            return RedirectToAction("Index");
        }


        // GET: /Delete/SellOffer
        public ActionResult Delete(int id)
        {
            _SellOfferRepo.RemoveOffer(id);
            return RedirectToAction("Index");
        }
    }
}
