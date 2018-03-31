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
        private IUnitOfWork _unitOfWork;
        
        public CategoryController(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View(_unitOfWork.Repository<Category>().ToList());
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
                _unitOfWork.Repository<Category>().Add(new Domain.Category() { Name = name });
                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            _unitOfWork.Repository<Category>().Remove(_unitOfWork.Repository<Category>().SingleOrDefault(c => c.Id == id));
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
