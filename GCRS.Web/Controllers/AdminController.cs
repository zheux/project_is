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
        private IAdminRepository _adminRepo;
        
        public AdminController(IAdminRepository AdminRepository)
        {
            _adminRepo = AdminRepository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(_adminRepo.GetAdmins());
        }

    }
}
