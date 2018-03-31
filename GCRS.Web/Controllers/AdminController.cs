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
        private IUnitOfWork _unitOfWork;
        
        public AdminController(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(_unitOfWork.Repository<Admin>().ToList());
        }

    }
}
