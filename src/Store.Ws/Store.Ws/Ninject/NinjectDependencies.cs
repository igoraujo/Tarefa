using Ninject;
using StoreWS.Service;
using StoreWS.UnitOfWork;
using System.Web.Mvc;

namespace StoreWS.Ninject
{
    public class NinjectDependencies
    {
        public static void ConfigureDependencies()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork.UnitOfWork>();
            kernel.Bind<IClientService>().To<ClientService>();            
            kernel.Bind<IImportService>().To<ImportService>();

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}