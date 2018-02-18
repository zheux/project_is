using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Data;

namespace GCRS.Web.Controllers
{
    public class MunicipiosController : Controller
    {
        // GET: Municipios
        public ActionResult Index()
        {
            return View(AppDatabase.GetMunicipios());
        }



        // GET: Nomenclador/AddMunicipio
        public ActionResult AddMunicipio()
        {
            return View();
        }

        // POST: Nomenclador/AddMunicipio
        [HttpPost]
        public ActionResult AddMunicipio(string nombre)
        {
            if (nombre == "")
            {
                ModelState.AddModelError("Nombre", "El nombre no puede ser vacío!");
                return View();
            }
            else
            {
                AppDatabase.AddMunicipio(new Domain.Municipio() { Nombre = nombre });
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            AppDatabase.RemoveMunicipio(id);
            return RedirectToAction("Index");
        }
    }
}
