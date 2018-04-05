using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{
    public class DistrictController : Controller
    {
        private IUnitOfWork unitOfWork;
        
        public DistrictController(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        // GET: District
        public ActionResult Index()
        {
            return View(unitOfWork.Repository<District>().ToList());
        }



        // GET: District/AddDistrict
        public ActionResult AddDistrict()
        {
            return View();
        }

        // POST: District/AddDistrict
        [HttpPost]
        public ActionResult AddDistrict(string name)
        {
            if (name == "")
            {
                ModelState.AddModelError("Name", "El nombre no puede ser vacío!");
                return View();
            }
            else
            {
                unitOfWork.Repository<District>().Add(new Domain.District() { Name = name });
                unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // GET: District/Delete/5
        public ActionResult Delete(int id)
        {
            unitOfWork.Repository<District>().Remove(unitOfWork.Repository<District>().SingleOrDefault(m => m.Id == id));
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
