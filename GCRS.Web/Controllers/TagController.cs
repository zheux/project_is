using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{
    public class TagController : Controller
    {
        private ITagRepository _tagRepo;
        
        public TagController(ITagRepository TagRepository)
        {
            _tagRepo = TagRepository;
        }

        // GET: Tags
        public ActionResult Index()
        {
            return View(_tagRepo.GetTags());
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
            _tagRepo.AddTag(new Tag {  Name = Name, Description = Destription, TagType = TagType == "All"? Domain.TagType.All: 
                TagType == "Rental"? Domain.TagType.Rental: Domain.TagType.Sell});
            return RedirectToAction("Index");
        }


        // GET: Nomenclador/Delete/5
        public ActionResult Delete(int id)
        {
            _tagRepo.RemoveTag(id);
            return RedirectToAction("Index");
        }
    }
}
