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
        private IUnitOfWork unitOfWork;
        
        public RentTimeUnitController(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        // GET: UnidadesTiempoRenta
        public ActionResult Index()
        {
            return View(unitOfWork.Repository<RentTimeUnit>().ToList());
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
                unitOfWork.Repository<RentTimeUnit>().Add(new Domain.RentTimeUnit() { Name = name });
                unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            unitOfWork.Repository<RentTimeUnit>().Remove(unitOfWork.Repository<RentTimeUnit>().SingleOrDefault(r => r.Id == id));
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
