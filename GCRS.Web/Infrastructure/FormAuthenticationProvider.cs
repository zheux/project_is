using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using GCRS.Data.Repositories;

namespace GCRS.Web.Infrastructure
{
    public class FormAuthenticationProvider : IAuthProvider
    {
        private ClientRepository _clientRepo;
        private AgentRepository _agentRepo;
        private AdminRepository _adminRepo;

        public FormAuthenticationProvider()
        {
            _clientRepo = new ClientRepository();
            _adminRepo = new AdminRepository();
            _agentRepo = new AgentRepository();
        }

        public bool Authenticate(string username, string password, bool remember)
        {
            var client = _clientRepo.FindClient(c => c.Username == username);
            var admin = _adminRepo.FindAdmin(a => a.Username == username);
            var agent = _agentRepo.FindAgent(a => a.Username == username);
            bool result = (client != null && client.Password == password) || (admin != null && admin.Password == password) || (agent != null && agent.Password == password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, remember);
            }
            return result;
        }

        public void LogOff()
        {
            FormsAuthentication.SignOut();
        }
    }
}