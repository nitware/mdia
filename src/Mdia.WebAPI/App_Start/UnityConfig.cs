using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

using Mdia.Data;
using Mdia.Business.Interfaces;
using Mdia.Business;
using Mdia.Model.Model;
using Mdia.Utility.Interfaces;
using Mdia.Utility;

namespace Mdia.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers


            string basePath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            
            container.RegisterType<IRepository, Repository>();
            container.RegisterType<ICryptoService, CryptoService>();
            container.RegisterType<IMembershipService, MembershipService>();
            container.RegisterType<INotificationProvider<Email, bool>, EmailService>();
            container.RegisterType<IFileManager, FileManager>(new InjectionConstructor(basePath));
            container.RegisterType<IContentProvider, ContentProvider>();
            container.RegisterType<ILogger, Logger>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }



    }
}