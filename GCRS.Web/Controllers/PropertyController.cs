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
    public class PropertyController : Controller
    {
        private UnitOfWork unitOfWork;
        
        public PropertyController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: Properties
        public ActionResult Index()
        {
            return View(unitOfWork.Repository<Property>().ToList());
        }



        // GET: AddProperty
        public ActionResult AddProperty()
        {
            return View(new PropertyViewModels {
                Property = new Property(),
                Categories = unitOfWork.Repository<Category>().ToList(),
                Districts = unitOfWork.Repository<District>().ToList(),
                Municipalities = unitOfWork.Repository<Municipality>().ToList(),
                Provinces = unitOfWork.Repository<Province>().ToList()
            });
        }

        // POST: AddProperty
        [HttpPost]
        public ActionResult AddProperty(Property Property)
        {
            if (Property.Category == null)
                ModelState.AddModelError("Property.Category.Name", "Hay que escoger una categoria!");
            if (Property.District == null)
                ModelState.AddModelError("Property.District.Name", "Hay que escoger un distrito!");
            if (Property.Municipality == null)
                ModelState.AddModelError("Property.Municipality.Name", "Hay que escoger un municipio!");
            if (Property.Province == null)
                ModelState.AddModelError("Property.Province.Name", "Hay que escoger una provincia!");

            if (!ModelState.IsValid)
                return View(new PropertyViewModels
                {
                    Property = new Property(),
                    Categories = unitOfWork.Repository<Category>().ToList(),
                    Districts = unitOfWork.Repository<District>().ToList(),
                    Municipalities = unitOfWork.Repository<Municipality>().ToList(),
                    Provinces = unitOfWork.Repository<Province>().ToList()
                });

            unitOfWork.Repository<Property>().Add(new Domain.Property()
            {
                Direccion = Property.Direccion,
                ProvinceId = unitOfWork.Repository<Province>().SingleOrDefault(x => x.Name == Property.Province.Name).Id,
                MunicipalityId = unitOfWork.Repository<Municipality>().SingleOrDefault(x => x.Name == Property.Municipality.Name).Id,
                DistrictId = unitOfWork.Repository<District>().SingleOrDefault(x => x.Name == Property.District.Name).Id,
                CategoryId = unitOfWork.Repository<Category>().SingleOrDefault(x => x.Name == Property.Category.Name).Id,
                RoomsCount = Property.RoomsCount,
                InfoAdicional = Property.InfoAdicional
            });
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: /Delete/Property
        public ActionResult Delete(int id)
        {
            unitOfWork.Repository<Property>().Remove(unitOfWork.Repository<Property>().SingleOrDefault(m => m.Id == id));
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
