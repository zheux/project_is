using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Data;

namespace GCRS.Web.Controllers
{
    public class MunicipalityController : Controller
    {
        // GET: Municipios
        public ActionResult Index()
        {
            return View(AppDatabase.GetMunicipalities());
        }



        // GET: Nomenclador/AddMunicipio
        public ActionResult AddMunicipality()
        {
            return View();
        }

        // POST: Nomenclador/AddMunicipio
        [HttpPost]
        public ActionResult AddMunicipality(string name)
        {
            if (name == "")
            {
                ModelState.AddModelError("Name", "El nombre no puede ser vacío!");
                return View();
            }
            else
            {
                AppDatabase.AddMunicipality(new Domain.Municipality() { Name = name });
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            AppDatabase.RemoveMunicipality(id);
            return RedirectToAction("Index");
        }
    }
}
