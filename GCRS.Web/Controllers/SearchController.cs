using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Web.ViewModels;
using GCRS.Domain;
using GCRS.Services;

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
                FilteredRentals = _searchService.SearchRentalOffers(m => m.Id != 0),
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
            Func<RentalOffer, bool> cond = m => {
                bool ret = true;
                if (filters.MaximumPrice < filters.MinimumPrice || m.PricePerRTU > filters.MaximumPrice || filters.MinimumPrice > m.PricePerRTU)
                    ret = false;
                if (filters.MaximumPrice == 0 && filters.MinimumPrice == 0)
                    ret = true;
                if (m.Title.Split().Contains(filters.Keywords))
                    ret = true;
                if (filters.SelectedCategory != null && (m.Property.Category == null || m.Property.Category.Name != filters.SelectedCategory))
                    ret = false;
                if (filters.SelectedProvince != null && (m.Property.Province == null || m.Property.Province.Name != filters.SelectedProvince))
                    ret = false;
                if (filters.SelectedDistrict != null && (m.Property.District == null || m.Property.District.Name != filters.SelectedDistrict))
                    ret = false;
                if (filters.SelectedMunicipality != null && (m.Property.Municipality == null || m.Property.Municipality.Name != filters.SelectedMunicipality))
                    ret = false;
                return ret;
            };
            IEnumerable<RentalOffer> s = _searchService.SearchRentalOffers(cond);
            return View(new RentalSearchVM()
            {
                FilteredRentals = _searchService.SearchRentalOffers(cond),
                Provinces = _provinceRepo.GetProvinces(),
                Municipalities = _municipalityRepo.GetMunicipalities(),
                Districts = _districtRepo.GetDistricts(),
                Categories = _categoryRepo.GetCategories()
            });
        }
    }
}