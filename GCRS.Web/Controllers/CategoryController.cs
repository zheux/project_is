using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Data;

namespace GCRS.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View(AppDatabase.GetCategories());
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
                AppDatabase.AddCategory(new Domain.Category() { Name = name });
            }
            return RedirectToAction("Index");
        }


        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            AppDatabase.RemoveCategory(id);
            return RedirectToAction("Index");
        }
    }
}
