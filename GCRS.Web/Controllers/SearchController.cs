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
        private IUnitOfWork unitOfWork;
        private SearchService _searchService;

        public SearchController(IUnitOfWork UnitOfWork, SearchService Service)
        {
            unitOfWork = UnitOfWork;
            _searchService = Service;
        }

        // GET: Search
        public ActionResult Rental()
        {
            return View(new RentalSearchVM() {
                FilteredRentals = _searchService.SearchRentalOffers(null, unitOfWork.Repository<Tag>().ToList()),
                Provinces = unitOfWork.Repository<Province>().ToList(),
                Municipalities = unitOfWork.Repository<Municipality>().ToList(),
                Districts = unitOfWork.Repository<District>().ToList(),
                Categories = unitOfWork.Repository<Category>().ToList(),
                Tags = unitOfWork.Repository<Tag>().ToList()
            });
        }

        // POST: Search
        [HttpPost]
        public ActionResult Rental(RentalSearchFilterVM filters)
        {
            return View(new RentalSearchVM()
            {
                FilteredRentals = _searchService.SearchRentalOffers(filters, unitOfWork.Repository<Tag>().ToList()),
                Provinces = unitOfWork.Repository<Province>().ToList(),
                Municipalities = unitOfWork.Repository<Municipality>().ToList(),
                Districts = unitOfWork.Repository<District>().ToList(),
                Categories = unitOfWork.Repository<Category>().ToList(),
                Tags = unitOfWork.Repository<Tag>().ToList()
            });
        }

        // GET: Sell
        public ActionResult Sell()
        {
            return View(new SellSearchVM()
            {
                FilteredSells = _searchService.SearchSellOffers(null, unitOfWork.Repository<Tag>().ToList()),
                Provinces = unitOfWork.Repository<Province>().ToList(),
                Municipalities = unitOfWork.Repository<Municipality>().ToList(),
                Districts = unitOfWork.Repository<District>().ToList(),
                Categories = unitOfWork.Repository<Category>().ToList(),
                Tags = unitOfWork.Repository<Tag>().ToList()
            });
        }

        // POST: Sell
        [HttpPost]
        public ActionResult Sell(SellSearchFilterVM filters)
        {
            return View(new SellSearchVM()
            {
                FilteredSells = _searchService.SearchSellOffers(filters, unitOfWork.Repository<Tag>().ToList()),
                Provinces = unitOfWork.Repository<Province>().ToList(),
                Municipalities = unitOfWork.Repository<Municipality>().ToList(),
                Districts = unitOfWork.Repository<District>().ToList(),
                Categories = unitOfWork.Repository<Category>().ToList(),
                Tags = unitOfWork.Repository<Tag>().ToList()
            });
        }
    }
}