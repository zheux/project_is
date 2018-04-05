using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{
    public class AgentController : Controller
    {
        private IUnitOfWork unitOfWork;
        
        public AgentController(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        // GET: Agent
        public ActionResult Index()
        {
            return View(unitOfWork.Repository<Agent>().ToList());
        }

    }
}
