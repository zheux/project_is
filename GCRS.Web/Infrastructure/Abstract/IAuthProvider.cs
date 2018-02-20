using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCRS.Web.Infrastructure
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password, bool remember);

        void LogOff();
    }
}