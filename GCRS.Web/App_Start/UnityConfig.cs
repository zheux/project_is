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
            container.RegisterType<IAdminRepository, AdminRepository>();
            container.RegisterType<IAgentRepository, AgentRepository>();

            container.RegisterType<IProvinceRepository, ProvinceRepository>();
            container.RegisterType<IMunicipalityRepository, MunicipalityRepository>();
            container.RegisterType<IDistrictRepository, DistrictRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IRentTimeUnitRepository, RentTimeUnitRepository>();
            container.RegisterType<ITagRepository, TagRepository>();
            container.RegisterType<IPropertyRepository, PropertyRepository>();
            container.RegisterType < IOfferRepository<SellOffer>, SellOfferRepository>();
            container.RegisterType<IOfferRepository<RentalOffer>, RentalOfferRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}