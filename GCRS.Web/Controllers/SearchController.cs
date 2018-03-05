using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Web.ViewModels;
using GCRS.Data;

namespace GCRS.Web.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Rental()
        {
            return View(new RentalSearchVM() { Provinces = AppDatabase.GetProvinces(), Municipalities = AppDatabase.GetMunicipalities(), Districts =  AppDatabase.GetDistricts(), Categories = AppDatabase.GetCategories()});
        }

        // POST: Search
        [HttpPost]
        public ActionResult Rental(RentalSearchFilterVM filters)
        {
            //TODO: realizar la busqueda alfanumerica
            return View();
        }
    }
}