using System.Web.Http;
using InsCompany.DataAccess.DataContext;
using InsCompany.DataAccess.Repository.PolicyRepository;
using InsCompany.DataAccess.Repository.RiskRepository;
using InsCompany.DataModel.Service.PolicyService;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace InsCompany.DataModel.App_Start
{
    public static class UnityConfig
    {
        private static UnityContainer container = new UnityContainer();

        public static UnityContainer GetConfiguredContainer()
        {
            return container;
        }

        public static void RegisterComponents()
        {
            container.RegisterType<InsCompanyContext>();

            container.RegisterType<IRiskRepository, RiskRepository>();

            container.RegisterType<IPolicyRepository, PolicyRepository>();

            container.RegisterType<IPolicyService, PolicyService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}