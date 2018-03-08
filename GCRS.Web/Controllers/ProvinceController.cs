using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{

    public class ProvinceController : Controller
    {
        private IProvinceRepository _provinceRepo;
        
        public ProvinceController(IProvinceRepository ProvinceRepository)
        {
            _provinceRepo = ProvinceRepository;
        }

        // GET: Provincias
        public ActionResult Index()
        {
            return View(_provinceRepo.GetProvinces());
        }

        // GET: Nomenclador/AddProvincia
        public ActionResult AddProvince()
        {
            return View();
        }

        // POST: Nomenclador/AddProvincia
        [HttpPost]
        public ActionResult AddProvince(string name)
        {
            if (name == "")
            {
                ModelState.AddModelError("Name", "El nombre no puede ser vacío!");
                return View();
            }
            else
            {
                _provinceRepo.AddProvince(new Domain.Province() { Name = name });
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            _provinceRepo.RemoveProvince(id);
            return RedirectToAction("Index");
        }
    }
}
