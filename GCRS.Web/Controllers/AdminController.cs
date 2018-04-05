using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{
    public class AdminController : Controller
    {
        private IUnitOfWork unitOfWork;
        
        public AdminController(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(unitOfWork.Repository<Admin>().ToList());
        }

    }
}
