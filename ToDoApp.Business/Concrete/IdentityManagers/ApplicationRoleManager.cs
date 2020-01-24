using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using ToDoApp.Entities.Identity.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ToDoApp.Entities.Identity;

namespace ToDoApp.Business.Concrete.IdentityManagers
{
    public class ApplicationRoleManager : RoleManager<Roles>
    {
        public ApplicationRoleManager(IRoleStore<Roles, string> roleStore)
            : base(roleStore)
        {

        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<Roles>(context.Get<IdentityContext>()));
        }
    }
}
