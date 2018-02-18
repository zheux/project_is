using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Data;

namespace GCRS.Web.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            return View(AppDatabase.GetCategorias());
        }



        // GET: Nomenclador/AddCategoria
        public ActionResult AddCategoria()
        {
            return View();
        }

        // POST: Nomenclador/AddCategoria
        [HttpPost]
        public ActionResult AddCategoria(string nombre)
        {
            if (nombre == "")
            {
                ModelState.AddModelError("Nombre", "El nombre no puede ser vacío!");
                return View();
            }
            else
            {
                AppDatabase.AddCategoria(new Domain.Categoria() { Nombre = nombre });
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            AppDatabase.RemoveCategoria(id);
            return RedirectToAction("Index");
        }
    }
}
