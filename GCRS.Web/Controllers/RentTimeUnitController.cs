using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{
    public class RentTimeUnitController : Controller
    {
        private IRentTimeUnitRepository _rentTimeUnitRepo;
        
        public RentTimeUnitController(IRentTimeUnitRepository RentTimeUnitRepository)
        {
            _rentTimeUnitRepo= RentTimeUnitRepository;
        }

        // GET: UnidadesTiempoRenta
        public ActionResult Index()
        {
            return View(_rentTimeUnitRepo.GetRentTimeUnits());
        }



        // GET: Nomenclador/AddUnidadTiempoRenta
        public ActionResult AddRentTimeUnit()
        {
            return View();
        }

        // POST: Nomenclador/AddUnidadTiempoRenta
        [HttpPost]
        public ActionResult AddRentTimeUnit(string name)
        {
            if (name == "")
            {
                ModelState.AddModelError("Name", "El nombre no puede ser vacío!");
                return View();
            }
            else
            {
                _rentTimeUnitRepo.AddRentTimeUnit(new Domain.RentTimeUnit() { Name = name });
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            _rentTimeUnitRepo.RemoveRentTimeUnit(id);
            return RedirectToAction("Index");
        }
    }
}
