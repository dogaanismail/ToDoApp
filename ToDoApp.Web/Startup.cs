using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ToDoApp.Web.Startup))]

namespace ToDoApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
