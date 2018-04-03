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
        private ITagRepository _tagRepo;
        private SearchService _searchService;

        public SearchController(IProvinceRepository provinceRepo, IMunicipalityRepository municipalityRepo, IDistrictRepository districtRepo, ICategoryRepository categoryRepo, ITagRepository tagRepo)
        {
            _provinceRepo = provinceRepo;
            _municipalityRepo = municipalityRepo;
            _districtRepo = districtRepo;
            _categoryRepo = categoryRepo;
            _tagRepo = tagRepo;
            _searchService = new SearchService();
        }

        // GET: Search
        public ActionResult Rental()
        {
            return View(new RentalSearchVM() {
                FilteredRentals = _searchService.SearchRentalOffers(null, _tagRepo.GetTags().ToList()),
                Provinces = _provinceRepo.GetProvinces(),
                Municipalities = _municipalityRepo.GetMunicipalities(),
                Districts = _districtRepo.GetDistricts(),
                Categories = _categoryRepo.GetCategories(),
                Tags = _tagRepo.GetTags()
            });
        }

        // POST: Search
        [HttpPost]
        public ActionResult Rental(RentalSearchFilterVM filters)
        {
            return View(new RentalSearchVM()
            {
                FilteredRentals = _searchService.SearchRentalOffers(filters, _tagRepo.GetTags().ToList()),
                Provinces = _provinceRepo.GetProvinces(),
                Municipalities = _municipalityRepo.GetMunicipalities(),
                Districts = _districtRepo.GetDistricts(),
                Categories = _categoryRepo.GetCategories(),
                Tags = _tagRepo.GetTags()
            });
        }

        // GET: Sell
        public ActionResult Sell()
        {
            return View(new SellSearchVM()
            {
                FilteredSells = _searchService.SearchSellOffers(null, _tagRepo.GetTags().ToList()),
                Provinces = _provinceRepo.GetProvinces(),
                Municipalities = _municipalityRepo.GetMunicipalities(),
                Districts = _districtRepo.GetDistricts(),
                Categories = _categoryRepo.GetCategories(),
                Tags = _tagRepo.GetTags()
            });
        }

        // POST: Sell
        [HttpPost]
        public ActionResult Sell(SellSearchFilterVM filters)
        {
            return View(new SellSearchVM()
            {
                FilteredSells = _searchService.SearchSellOffers(filters, _tagRepo.GetTags().ToList()),
                Provinces = _provinceRepo.GetProvinces(),
                Municipalities = _municipalityRepo.GetMunicipalities(),
                Districts = _districtRepo.GetDistricts(),
                Categories = _categoryRepo.GetCategories(),
                Tags = _tagRepo.GetTags()
            });
        }
    }
}