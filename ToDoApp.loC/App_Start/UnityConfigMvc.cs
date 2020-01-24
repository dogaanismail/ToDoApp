using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.Mvc;
using ToDoApp.Business.Concrete.IdentityManagers;
using ToDoApp.Entities.Identity;
using ToDoApp.Entities.Identity.Entities;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;

namespace ToDoApp.loC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfigMvc
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }


        private static void RegisterTypes(IUnityContainer container)
        {
            /* For more information about these implementations please check out my website https://ismaildogaan.com/2019/08/15/asp-net-mvc-identity-icin-unity-dependency-injection-konfigurasyonu/ */
            container.RegisterType<IdentityContext>(new PerRequestLifetimeManager());
            container.RegisterType<ApplicationSignInManager>(new PerRequestLifetimeManager());
            container.RegisterType<ApplicationRoleManager>(new PerRequestLifetimeManager());
            container.RegisterType<ApplicationUserManager>(new PerRequestLifetimeManager());
            container.RegisterType<EmailService>();

            container.RegisterType<IAuthenticationManager>(
              injectionMembers: new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            container.RegisterType<IRoleStore<Roles, string>, RoleStore<Roles, string, IdentityUserRole>>(
              new InjectionConstructor(typeof(IdentityContext)));

            container.RegisterType<IUserStore<User>, UserStore<User>>(
                new InjectionConstructor(typeof(IdentityContext)));

        }

        public static void BindInRequstScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new HierarchicalLifetimeManager());
        }
    }
}