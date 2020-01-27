using Microsoft.Owin.Security;
using Ninject.Modules;
using System.Web;
using ToDoApp.Business.Concrete.IdentityManagers;
using ToDoApp.Core.CrossCuttingConcers.Security.AspNetIdentity;

namespace ToDoApp.Ninject.Modules
{
    public class IdendityModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ApplicationUserManager>().ToMethod(GetOwin.GetOwinInjection<ApplicationUserManager>);
            Bind<ApplicationSignInManager>().ToMethod(GetOwin.GetOwinInjection<ApplicationSignInManager>);
            Bind<ApplicationRoleManager>().ToMethod(GetOwin.GetOwinInjection<ApplicationRoleManager>);

            Bind<IAuthenticationManager>().ToMethod(context =>
            {
                var contextBase = new HttpContextWrapper(HttpContext.Current);
                return contextBase.GetOwinContext().Authentication;
            });

        }
    }
}
