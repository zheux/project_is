using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Data;

namespace GCRS.Web.Controllers
{
    public class ProvinciasController : Controller
    {
        // GET: Provincias
        public ActionResult Index()
        {
            return View(AppDatabase.GetProvincias());
        }



        // GET: Nomenclador/AddProvincia
        public ActionResult AddProvincia()
        {
            return View();
        }

        // POST: Nomenclador/AddProvincia
        [HttpPost]
        public ActionResult AddProvincia(string nombre)
        {
            if (nombre == "")
            {
                ModelState.AddModelError("Nombre", "El nombre no puede ser vacío!");
                return View();
            }
            else
            {
                AppDatabase.AddProvincia(new Domain.Provincia() { Nombre = nombre });
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            AppDatabase.RemoveProvincia(id);
            return RedirectToAction("Index");
        }
    }
}
