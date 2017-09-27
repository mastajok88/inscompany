using System.Web.Http;
using InsCompany.DataModel.DataContext;
using InsCompany.DataModel.Repository.PolicyRepository;
using InsCompany.DataModel.Repository.RiskRepository;
using Microsoft.Practices.Unity;
using Unity.WebApi;
using InsCompany.DataModel.Service;

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