using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using GCRS.Data;

namespace GCRS.Web.Infrastructure
{
    public class FormAuthenticationProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password, bool remember)
        {
            var client = AppDatabase.FindClient(username);
            var admin = AppDatabase.FindAdmin(username);
            var agent = AppDatabase.FindAgent(username);
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