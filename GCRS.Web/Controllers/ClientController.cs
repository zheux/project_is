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
        private IUnitOfWork _unitOfWork;

        public ClientController(IUnitOfWork UnitOfWork)
            :base()
        {
            _unitOfWork = UnitOfWork;
        }

        // GET: Client
        public ActionResult Index()
        {
            return View(_unitOfWork.Repository<Client>().ToList());
        }
    }
}
