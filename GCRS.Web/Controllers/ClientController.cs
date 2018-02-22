using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Data;
using GCRS.Web.ViewModels;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View(AppDatabase.GetClients());
        }
    }
}
