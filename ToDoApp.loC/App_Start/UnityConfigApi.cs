using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Http;
using ToDoApp.Business.Abstract;
using ToDoApp.Business.Concrete.IdentityManagers;
using ToDoApp.Business.Concrete.Managers;
using ToDoApp.DataAccess.Abstract.EntityFramework;
using ToDoApp.DataAccess.Concrete.EntityFramework;
using ToDoApp.Entities.Identity;
using ToDoApp.Entities.Identity.Entities;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.WebApi;

namespace ToDoApp.loC
{
    public static class UnityConfigApi
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

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


            /* For more information about these implementations please 
          * check out my website https://ismaildogaan.com/2019/08/15/asp-net-mvc-identity-icin-unity-dependency-injection-konfigurasyonu/ */

            container.RegisterType<ITaskService, TaskManager>();
            container.RegisterType<ITaskDal, EfTaskDal>();

            container.RegisterType<IUserTaskService, UserTaskManager>();
            container.RegisterType<IUserTaskDal, EfUserTaskDal>();

            container.BindInRequstScope<ITaskService, TaskManager>();
            container.BindInRequstScope<ITaskDal, EfTaskDal>();

            container.BindInRequstScope<IUserTaskService, UserTaskManager>();
            container.BindInRequstScope<IUserTaskDal, EfUserTaskDal>();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}