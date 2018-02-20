using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace GCRS.Web.Infrastructure
{
    public class FormAuthenticationProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password, bool remember)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
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