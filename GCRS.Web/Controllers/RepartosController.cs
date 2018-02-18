using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Data;

namespace GCRS.Web.Controllers
{
    public class RepartosController : Controller
    {
        // GET: Repartos
        public ActionResult Index()
        {
            return View(AppDatabase.GetRepartos());
        }



        // GET: Nomenclador/AddReparto
        public ActionResult AddReparto()
        {
            return View();
        }

        // POST: Nomenclador/AddReparto
        [HttpPost]
        public ActionResult AddReparto(string nombre)
        {
            if (nombre == "")
            {
                ModelState.AddModelError("Nombre", "El nombre no puede ser vacío!");
                return View();
            }
            else
            {
                AppDatabase.AddReparto(new Domain.Reparto() { Nombre = nombre });
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            AppDatabase.RemoveReparto(id);
            return RedirectToAction("Index");
        }
    }
}
