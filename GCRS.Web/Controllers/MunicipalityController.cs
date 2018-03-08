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
        private IMunicipalityRepository _municipalityRepo;
        
        public MunicipalityController(IMunicipalityRepository MunicipalityRepository)
        {
            _municipalityRepo = MunicipalityRepository;
        }

        // GET: Municipios
        public ActionResult Index()
        {
            return View(_municipalityRepo.GetMunicipalities());
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
                _municipalityRepo.AddMunicipality(new Domain.Municipality() { Name = name });
            }
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            _municipalityRepo.RemoveMunicipality(id);
            return RedirectToAction("Index");
        }
    }
}
