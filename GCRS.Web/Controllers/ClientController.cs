using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Web.ViewModels;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{
    public class ClientController : Controller
    {
        private IUnitOfWork unitOfWork;

        public ClientController(IUnitOfWork UnitOfWork)
            :base()
        {
            unitOfWork = UnitOfWork;
        }

        // GET: Client
        public ActionResult Index()
        {
            return View(unitOfWork.Repository<Client>().ToList());
        }
    }
}
