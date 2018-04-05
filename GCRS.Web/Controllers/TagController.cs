using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;
using GCRS.Data;

namespace GCRS.Web.Controllers
{
    public class TagController : Controller
    {
        private UnitOfWork unitOfWork;
        
        public TagController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: Tags
        public ActionResult Index()
        {
            return View(unitOfWork.Repository<Tag>().ToList());
        }



        // GET: Nomenclador/AddTag
        public ActionResult AddTag()
        {
            return View();
        }

        // POST: Nomenclador/AddTag
        [HttpPost]
        public ActionResult AddTag(string Name, string Destription, string TagType)
        {
            if (Name == "")
            {
                ModelState.AddModelError("Name", "El nombre no puede ser vacío!");
                return View();
            }
            if (TagType == null)
            {
                ModelState.AddModelError("TagType", "Tiene que seleccionar un tipo");
                return View();
            }
            unitOfWork.Repository<Tag>().Add(new Tag {  Name = Name, Description = Destription, TagType = TagType == "All"? Domain.TagType.All: 
                TagType == "Rental"? Domain.TagType.Rental: Domain.TagType.Sell});
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            unitOfWork.Repository<Tag>().Remove(unitOfWork.Repository<Tag>().SingleOrDefault(m => m.Id == id));
            return RedirectToAction("Index");
        }
    }
}
