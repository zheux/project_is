using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;
using GCRS.Web.ViewModels;

namespace GCRS.Web.Controllers
{
    public class PropertyController : Controller
    {
        private IProvinceRepository _provinceRepo;
        private IMunicipalityRepository _municipalityRepo;
        private IDistrictRepository _districtRepo;
        private ICategoryRepository _categoryRepo;
        private IPropertyRepository _PropertyRepo;
        
        public PropertyController(IPropertyRepository PropertyRepository, IProvinceRepository provinceRepo, 
            IMunicipalityRepository municipalityRepo, IDistrictRepository districtRepo, ICategoryRepository categoryRepo)
        {
            _PropertyRepo = PropertyRepository;
            _provinceRepo = provinceRepo;
            _municipalityRepo = municipalityRepo;
            _districtRepo = districtRepo;
            _categoryRepo = categoryRepo;

        }

        // GET: Properties
        public ActionResult Index()
        {
            return View(_PropertyRepo.GetProperties());
        }



        // GET: AddProperty
        public ActionResult AddProperty()
        {
            return View(new PropertyViewModels {
                Property = new Property(),
                Categories = _categoryRepo.GetCategories(),
                Districts = _districtRepo.GetDistricts(),
                Municipalities = _municipalityRepo.GetMunicipalities(),
                Provinces = _provinceRepo.GetProvinces()
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
                    Categories = _categoryRepo.GetCategories(),
                    Districts = _districtRepo.GetDistricts(),
                    Municipalities = _municipalityRepo.GetMunicipalities(),
                    Provinces = _provinceRepo.GetProvinces()
                });

            _PropertyRepo.AddProperty(new Domain.Property()
            {
                Direccion = Property.Direccion,
                ProvinceId = _provinceRepo.FindProvince(x => x.Name == Property.Province.Name).Id,
                MunicipalityId = _municipalityRepo.FindMunicipality(x => x.Name == Property.Municipality.Name).Id,
                DistrictId = _districtRepo.FindDistrict(x => x.Name == Property.District.Name).Id,
                CategoryId = _categoryRepo.FindCategory(x => x.Name == Property.Category.Name).Id,
                RoomsCount = Property.RoomsCount,
                InfoAdicional = Property.InfoAdicional});
            return RedirectToAction("Index");
        }


        // GET: /Delete/Property
        public ActionResult Delete(int id)
        {
            _PropertyRepo.RemoveProperty(id);
            return RedirectToAction("Index");
        }
    }
}
