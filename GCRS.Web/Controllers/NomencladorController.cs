using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Data;

namespace GCRS.Web.Controllers
{
    public class NomencladorController : Controller
    {
        // GET: Nomenclador
        public ActionResult Index()
        {
            return View(new ViewModels.NomencladorViewModel()
            {
                Provincias = AppDatabase.GetProvincias(),
                Municipios = AppDatabase.GetMunicipios(),
                Repartos = AppDatabase.GetRepartos(),
                Categorias = AppDatabase.GetCategorias(),
                UnidadesTiempoRenta = AppDatabase.GetUnidadesTiempoRenta(),
            });
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
                ModelState.AddModelError("Nombre", "Ingrese un nombre !");
                return View();
            }
            else
            {
                AppDatabase.AddProvincia(new Domain.Provincia() { Nombre = nombre });
            }
            return RedirectToAction("Index");
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
                ModelState.AddModelError("Nombre", "El nombre no puede ser vacio !");
                return View();
            }
            else
            {
                AppDatabase.AddReparto(new Domain.Reparto() { Nombre = nombre });
            }
            return RedirectToAction("Index");
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
                ModelState.AddModelError("Nombre", "El nombre no puede ser vacio !");
                return View();
            }
            else
            {
                AppDatabase.AddCategoria(new Domain.Categoria() { Nombre = nombre });
            }
            return RedirectToAction("Index");
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
                ModelState.AddModelError("Nombre", "El nombre no puede ser vacio !");
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
            AppDatabase.RemoveProvincia(id);
            AppDatabase.RemoveMunicipio(id);
            AppDatabase.RemoveReparto(id);
            AppDatabase.RemoveCategoria(id);
            AppDatabase.RemoveUnidadTiempoRenta(id);
            return RedirectToAction("Index");
        }
    }
}
