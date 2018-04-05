using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using GCRS.Data;
using GCRS.Domain;

namespace GCRS.Web.Infrastructure
{
    public class FormAuthenticationProvider : IAuthProvider
    {
        private IUnitOfWork unitOfWork;

        public FormAuthenticationProvider()
        {
            unitOfWork = new UnitOfWork();
        }

        public bool Authenticate(string username, string password, bool remember)
        {
            var client = unitOfWork.Repository<Client>().SingleOrDefault(c => c.Username == username);
            var admin = unitOfWork.Repository<Admin>().SingleOrDefault(a => a.Username == username);
            var agent = unitOfWork.Repository<Agent>().SingleOrDefault(a => a.Username == username);
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