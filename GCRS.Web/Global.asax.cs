using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;
using GCRS.Data.Repositories;

namespace GCRS.Web
{
    public class Global : System.Web.HttpApplication
    {
        ClientRepository _clientRepo;
        AdminRepository _adminRepo;
        AgentRepository _agentRepo;

        public Global(): base()
        {
            _clientRepo = new ClientRepository();
            _adminRepo = new AdminRepository();
            _agentRepo = new AgentRepository();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if(HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id =
                            (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;

                        //TODO: Determinar el rol del usuario usando el 'modelo' para guardarlo
                        string[] roles = { "" };
                        var curUser = HttpContext.Current.User.Identity;

                        if (_adminRepo.FindAdmin(a => a.Username == curUser.Name) != null)
                            roles[0] = "admin";
                        else if (_agentRepo.FindAgent(a => a.Username == curUser.Name) != null)
                            roles[0] = "agent";
                        else if (_clientRepo.FindClient(c => c.Username == curUser.Name) != null)
                            roles[0] = "client";

                        HttpContext.Current.User = new GenericPrincipal(id, roles);
                    }
                }
            }
        }
    }
}