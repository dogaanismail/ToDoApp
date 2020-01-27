using Microsoft.AspNet.Identity.Owin;
using Ninject.Activation;
using System.Web;

namespace ToDoApp.Core.CrossCuttingConcers.Security.AspNetIdentity
{
    public class GetOwin
    {
        /// <summary>
        /// Dependency injection for ASP.Net Identity 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <returns></returns>
        public static T GetOwinInjection<T>(IContext context) where T : class
        {
            var contextBase = new HttpContextWrapper(HttpContext.Current);
            return contextBase.GetOwinContext().Get<T>();
        }
    }
}
