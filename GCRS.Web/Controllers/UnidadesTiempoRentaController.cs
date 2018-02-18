using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Data;

namespace GCRS.Web.Controllers
{
    public class UnidadesTiempoRentaController : Controller
    {
        // GET: UnidadesTiempoRenta
        public ActionResult Index()
        {
            return View(AppDatabase.GetUnidadesTiempoRenta());
        }



        // GET: Nomenclador/AddUnidadTiempoRenta
        public ActionResult AddUnidadTiempoRenta()
        {
            return View();
        }

        // POST: Nomenclador/AddUnidadTiempoRenta
        [HttpPost]
        public ActionResult AddUnidadTiempoRenta(string nombre)
        {
            if (nombre == "")
            {
                ModelState.AddModelError("Nombre", "El nombre no puede ser vacío!");
                return View();
            }
            else
            {
                AppDatabase.AddUnidadTiempoRenta(new Domain.UnidadTiempoRenta() { Nombre = nombre });
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            AppDatabase.RemoveUnidadTiempoRenta(id);
            return RedirectToAction("Index");
        }
    }
}
