using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Data;

namespace GCRS.Web.Controllers
{
    public class DistrictController : Controller
    {
        // GET: District
        public ActionResult Index()
        {
            return View(AppDatabase.GetDistricts());
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
                AppDatabase.AddDistrict(new Domain.District() { Name = name });
            }
            return RedirectToAction("Index");
        }


        // GET: District/Delete/5
        public ActionResult Delete(int id)
        {
            AppDatabase.RemoveDistrict(id);
            return RedirectToAction("Index");
        }
    }
}
