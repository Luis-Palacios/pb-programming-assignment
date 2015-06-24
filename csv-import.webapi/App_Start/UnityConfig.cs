using csv_import.datalayer.Repositories;
using csv_import.domain;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace csv_import.webapi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IGenericRepository<ImportResult>, EntityFrameworkRepository<ImportResult> >();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}