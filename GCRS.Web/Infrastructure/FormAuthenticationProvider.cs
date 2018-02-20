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
            bool result = AuthenticateUser(username, password);
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

        private bool AuthenticateUser(string username, string password)
        {
            //TODO: llamar al 'modelo' para verificar si los datos son validos
            return true;
        }
    }
}