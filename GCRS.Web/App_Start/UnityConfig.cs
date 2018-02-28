using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using GCRS.Web.Infrastructure;
using GCRS.Domain;
using GCRS.Data.Repositories;

namespace GCRS.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IAuthProvider, FormAuthenticationProvider>();

            container.RegisterType<IClientRepository, ClientRepository>();
            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}