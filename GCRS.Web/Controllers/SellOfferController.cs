using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;
using GCRS.Web.ViewModels;
using GCRS.Data;

namespace GCRS.Web.Controllers
{
    public class SellOfferController : Controller
    {
        private UnitOfWork unitOfWork;

        public SellOfferController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: Properties
        public ActionResult Index()
        {
            return View(unitOfWork.Repository<SellOffer>().ToList());
        }



        // GET: AddSellOffer
        public ActionResult AddSellOffer()
        {
            return View(new SellOfferViewModels
            {
                Offer = new SellOffer(),
                Agents = unitOfWork.Repository<Agent>().ToList(),
                Clients = unitOfWork.Repository<Client>().ToList(),
                Properties = unitOfWork.Repository<Property>().ToList(),
                Tags = unitOfWork.Repository<Tag>().ToList()
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
                    Agents = unitOfWork.Repository<Agent>().ToList(),
                    Clients = unitOfWork.Repository<Client>().ToList(),
                    Properties = unitOfWork.Repository<Property>().ToList(),
                    Tags = unitOfWork.Repository<Tag>().ToList()
                });


            unitOfWork.Repository<SellOffer>().Add(new Domain.SellOffer()
            {
                Agent = Offer.Agent,
                Tags = Offer.Tags,
                PropertyId = Offer.PropertyId,
                ClientUserName = Offer.ClientUserName,
                Comission = 100,
                Description = Offer.Description,
                Price = Offer.Price,
                State = OfferState.Published,
                Title = Offer.Title
            });
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: /Delete/SellOffer
        public ActionResult Delete(int id)
        {

            unitOfWork.Repository<SellOffer>().Remove(unitOfWork.Repository<SellOffer>().SingleOrDefault(m => m.Id == id));
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
