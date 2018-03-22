using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Web.ViewModels;
using GCRS.Domain;
using GCRS.Services;
using GCRS.Services.ViewModels;

namespace GCRS.Web.Controllers
{
    public class SearchController : Controller
    {
        private IProvinceRepository _provinceRepo;
        private IMunicipalityRepository _municipalityRepo;
        private IDistrictRepository _districtRepo;
        private ICategoryRepository _categoryRepo;
        private SearchService _searchService;

        public SearchController(IProvinceRepository provinceRepo, IMunicipalityRepository municipalityRepo, IDistrictRepository districtRepo, ICategoryRepository categoryRepo)
        {
            _provinceRepo = provinceRepo;
            _municipalityRepo = municipalityRepo;
            _districtRepo = districtRepo;
            _categoryRepo = categoryRepo;
            _searchService = new SearchService();
        }

        // GET: Search
        public ActionResult Rental()
        {
            return View(new RentalSearchVM() {
                FilteredRentals = _searchService.SearchRentalOffers(null),
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
            return View(new RentalSearchVM()
            {
                FilteredRentals = _searchService.SearchRentalOffers(filters),
                Provinces = _provinceRepo.GetProvinces(),
                Municipalities = _municipalityRepo.GetMunicipalities(),
                Districts = _districtRepo.GetDistricts(),
                Categories = _categoryRepo.GetCategories()
            });
        }

        // GET: Sell
        public ActionResult Sell()
        {
            return View(new SellSearchVM()
            {
                FilteredSells = _searchService.SearchSellOffers(null),
                Provinces = _provinceRepo.GetProvinces(),
                Municipalities = _municipalityRepo.GetMunicipalities(),
                Districts = _districtRepo.GetDistricts(),
                Categories = _categoryRepo.GetCategories()
            });
        }

        // POST: Sell
        [HttpPost]
        public ActionResult Sell(SellSearchFilterVM filters)
        {
            return View(new SellSearchVM()
            {
                FilteredSells = _searchService.SearchSellOffers(filters),
                Provinces = _provinceRepo.GetProvinces(),
                Municipalities = _municipalityRepo.GetMunicipalities(),
                Districts = _districtRepo.GetDistricts(),
                Categories = _categoryRepo.GetCategories()
            });
        }
    }
}