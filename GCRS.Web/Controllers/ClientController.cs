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
        private IClientRepository _clientRepo;

        public ClientController(IClientRepository ClientRepository)
            :base()
        {
            _clientRepo = ClientRepository;
        }

        // GET: Client
        public ActionResult Index()
        {
            return View(_clientRepo.GetClients());
        }
    }
}
