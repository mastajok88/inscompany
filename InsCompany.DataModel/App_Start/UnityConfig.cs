using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using InsCompany.DataModel.DataContext;
using InsCompany.DataModel.Repository;
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

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}