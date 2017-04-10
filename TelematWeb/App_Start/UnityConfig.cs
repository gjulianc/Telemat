using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Data.Interfaz;
using Data.EFRepository;

namespace TelematWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ITransaccionRepository, TransaccionRepository>();
            container.RegisterType<IBaseRepostajeRepository, BaseRepostajeRepository>();
            container.RegisterType<IDepositoRepository, DepositoRepository>();
            container.RegisterType<IMangueraRepository, MangueraRepository>();
            container.RegisterType<IVehiculoRepository, VehiculoRepository>();
            container.RegisterType<ITramaGPSRepository, TramaGPSREpository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}