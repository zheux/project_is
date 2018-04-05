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
        private IUnitOfWork unitOfWork;
        
        public CategoryController(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View(unitOfWork.Repository<Category>().ToList());
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
                unitOfWork.Repository<Category>().Add(new Domain.Category() { Name = name });
                unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            unitOfWork.Repository<Category>().Remove(unitOfWork.Repository<Category>().SingleOrDefault(c => c.Id == id));
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
