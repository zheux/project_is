using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{
    public class MunicipalityController : Controller
    {
        private IUnitOfWork unitOfWork;
        
        public MunicipalityController(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        // GET: Municipios
        public ActionResult Index()
        {
            return View(unitOfWork.Repository<Municipality>().ToList());
        }



        // GET: Nomenclador/AddMunicipio
        public ActionResult AddMunicipality()
        {
            return View();
        }

        // POST: Nomenclador/AddMunicipio
        [HttpPost]
        public ActionResult AddMunicipality(string name)
        {
            if (name == "")
            {
                ModelState.AddModelError("Name", "El nombre no puede ser vacío!");
                return View();
            }
            else
            {
                unitOfWork.Repository<Municipality>().Add(new Domain.Municipality() { Name = name });
                unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            unitOfWork.Repository<Municipality>().Remove(unitOfWork.Repository<Municipality>().SingleOrDefault(m => m.Id == id));
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
