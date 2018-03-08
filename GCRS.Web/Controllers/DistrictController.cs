using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{
    public class DistrictController : Controller
    {
        private IDistrictRepository _districtRepo;
        
        public DistrictController(IDistrictRepository DistrictRepository)
        {
            _districtRepo = DistrictRepository;
        }

        // GET: District
        public ActionResult Index()
        {
            return View(_districtRepo.GetDistricts());
        }



        // GET: District/AddDistrict
        public ActionResult AddDistrict()
        {
            return View();
        }

        // POST: District/AddDistrict
        [HttpPost]
        public ActionResult AddDistrict(string name)
        {
            if (name == "")
            {
                ModelState.AddModelError("Name", "El nombre no puede ser vacío!");
                return View();
            }
            else
            {
                _districtRepo.AddDistrict(new Domain.District() { Name = name });
            }
            return RedirectToAction("Index");
        }


        // GET: District/Delete/5
        public ActionResult Delete(int id)
        {
            _districtRepo.RemoveDistrict(id);
            return RedirectToAction("Index");
        }
    }
}
