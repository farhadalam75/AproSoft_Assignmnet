using System.Web.Mvc;
using Farhad_Apro.Models;
using Farhad_Apro.Repository.Interface;
using Farhad_Apro.Repository.Manager;
using Unity;
using Unity.Mvc5;

namespace Farhad_Apro
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IGenericRepository<TeamDetails>, TeamDetailsRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}