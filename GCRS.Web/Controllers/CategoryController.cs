using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepo;
        
        public CategoryController(ICategoryRepository CategoryRepository)
        {
            _categoryRepo = CategoryRepository;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View(_categoryRepo.GetCategories());
        }



        // GET: Category/AddCategory
        public ActionResult AddCategory()
        {
            return View();
        }

        // POST: Category/AddCategory
        [HttpPost]
        public ActionResult AddCategory(string name)
        {
            if (name == "")
            {
                ModelState.AddModelError("Name", "El nombre no puede ser vacío!");
                return View();
            }
            else
            {
                _categoryRepo.AddCategory(new Domain.Category() { Name = name });
            }
            return RedirectToAction("Index");
        }


        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            _categoryRepo.RemoveCategory(id);
            return RedirectToAction("Index");
        }
    }
}
