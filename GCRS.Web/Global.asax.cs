using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;
using GCRS.Data;
using GCRS.Domain;

namespace GCRS.Web
{
    public class Global : System.Web.HttpApplication
    {
        UnitOfWork unitOfWork;

        public Global(): base()
        {
            unitOfWork = new UnitOfWork();
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

                        if (unitOfWork.Repository<Admin>().SingleOrDefault(a => a.Username == curUser.Name) != null)
                            roles[0] = "admin";
                        else if (unitOfWork.Repository<Agent>().SingleOrDefault(a => a.Username == curUser.Name) != null)
                            roles[0] = "agent";
                        else if (unitOfWork.Repository<Client>().SingleOrDefault(c => c.Username == curUser.Name) != null)
                            roles[0] = "client";

                        HttpContext.Current.User = new GenericPrincipal(id, roles);
                    }
                }
            }
        }
    }
}