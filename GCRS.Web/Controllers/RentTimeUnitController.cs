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
        private IUnitOfWork _unitOfWork;
        
        public RentTimeUnitController(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        // GET: UnidadesTiempoRenta
        public ActionResult Index()
        {
            return View(_unitOfWork.Repository<RentTimeUnit>().ToList());
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
                _unitOfWork.Repository<RentTimeUnit>().Add(new Domain.RentTimeUnit() { Name = name });
                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            _unitOfWork.Repository<RentTimeUnit>().Remove(_unitOfWork.Repository<RentTimeUnit>().SingleOrDefault(r => r.Id == id));
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
