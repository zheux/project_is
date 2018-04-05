using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{

    public class ProvinceController : Controller
    {
        private IUnitOfWork unitOfWork;
        
        public ProvinceController(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        // GET: Provincias
        public ActionResult Index()
        {
            return View(unitOfWork.Repository<Province>().ToList());
        }

        // GET: Nomenclador/AddProvincia
        public ActionResult AddProvince()
        {
            return View();
        }

        // POST: Nomenclador/AddProvincia
        [HttpPost]
        public ActionResult AddProvince(string name)
        {
            if (name == "")
            {
                ModelState.AddModelError("Name", "El nombre no puede ser vacío!");
                return View();
            }
            else
            {
                unitOfWork.Repository<Province>().Add(new Domain.Province() { Name = name });
                unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            unitOfWork.Repository<Province>().Remove(unitOfWork.Repository<Province>().SingleOrDefault(p => p.Id == id));
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
