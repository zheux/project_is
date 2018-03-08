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
        private IAgentRepository _agentRepo;
        
        public AgentController(IAgentRepository AgentRepository)
        {
            _agentRepo = AgentRepository;
        }

        // GET: Agent
        public ActionResult Index()
        {
            return View(_agentRepo.GetAgents());
        }

    }
}
