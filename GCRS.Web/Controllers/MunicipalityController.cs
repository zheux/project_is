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
        private IUnitOfWork _unitOfWork;
        
        public MunicipalityController(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        // GET: Municipios
        public ActionResult Index()
        {
            return View(_unitOfWork.Repository<Municipality>().ToList());
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
                _unitOfWork.Repository<Municipality>().Add(new Domain.Municipality() { Name = name });
                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            _unitOfWork.Repository<Municipality>().Remove(_unitOfWork.Repository<Municipality>().SingleOrDefault(m => m.Id == id));
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
