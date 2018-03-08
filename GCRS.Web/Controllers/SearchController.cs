using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Web.ViewModels;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{
    public class SearchController : Controller
    {
        private IProvinceRepository _provinceRepo;
        private IMunicipalityRepository _municipalityRepo;
        private IDistrictRepository _districtRepo;
        private ICategoryRepository _categoryRepo;

        public SearchController(IProvinceRepository provinceRepo, IMunicipalityRepository municipalityRepo, IDistrictRepository districtRepo, ICategoryRepository categoryRepo)
        {
            _provinceRepo = provinceRepo;
            _municipalityRepo = municipalityRepo;
            _districtRepo = districtRepo;
            _categoryRepo = categoryRepo;
        }

        // GET: Search
        public ActionResult Rental()
        {
            return View(new RentalSearchVM() {
                Provinces = _provinceRepo.GetProvinces(),
                Municipalities = _municipalityRepo.GetMunicipalities(),
                Districts = _districtRepo.GetDistricts(),
                Categories = _categoryRepo.GetCategories()
            });
        }

        // POST: Search
        [HttpPost]
        public ActionResult Rental(RentalSearchFilterVM filters)
        {
            //TODO: realizar la busqueda alfanumerica
            return View(new RentalSearchVM()
            {
                Provinces = _provinceRepo.GetProvinces(),
                Municipalities = _municipalityRepo.GetMunicipalities(),
                Districts = _districtRepo.GetDistricts(),
                Categories = _categoryRepo.GetCategories()
            });
        }
    }
}