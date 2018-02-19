using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Data;

namespace GCRS.Web.Controllers
{
    public class AgentesController : Controller
    {
        // GET: Agentes
        public ActionResult Index()
        {
            return View(AppDatabase.GetAgentes());
        }

    }
}
