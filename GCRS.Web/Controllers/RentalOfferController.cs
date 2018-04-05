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
    public class RentalOfferController : Controller
    {
        private UnitOfWork unitOfWork;
        
        public RentalOfferController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: Properties
        public ActionResult Index()
        {
            return View(unitOfWork.Repository<RentalOffer>().ToList());
        }



        // GET: AddRentalOffer
        public ActionResult AddRentalOffer()
        {
            return View(new RentalOfferViewModels {
                Offer = new RentalOffer(),
                Agents = unitOfWork.Repository<Agent>().ToList(),
                Clients = unitOfWork.Repository<Client>().ToList(),
                Properties = unitOfWork.Repository<Property>().ToList(),
                Tags = unitOfWork.Repository<Tag>().ToList(),
                RTU = unitOfWork.Repository<RentTimeUnit>().ToList()
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
                    Agents = unitOfWork.Repository<Agent>().ToList(),
                    Clients = unitOfWork.Repository<Client>().ToList(),
                    Properties = unitOfWork.Repository<Property>().ToList(),
                    Tags = unitOfWork.Repository<Tag>().ToList(),
                    RTU = unitOfWork.Repository<RentTimeUnit>().ToList()
                });


            unitOfWork.Repository<RentalOffer>().Add(new Domain.RentalOffer() { Agent = Offer.Agent, Tags = Offer.Tags, PropertyId = Offer.PropertyId,
                                ClientUserName = Offer.ClientUserName, Comission = 100, Description = Offer.Description, PricePerRTU = Offer.PricePerRTU,
                                State = OfferState.Published, Title = Offer.Title, RTU = unitOfWork.Repository<RentTimeUnit>().SingleOrDefault(m => m.Name == "Noche")});
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: /Delete/RentalOffer
        public ActionResult Delete(int id)
        {
            
            unitOfWork.Repository<RentalOffer>().Remove(unitOfWork.Repository<RentalOffer>().SingleOrDefault(m => m.Id == id));
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
