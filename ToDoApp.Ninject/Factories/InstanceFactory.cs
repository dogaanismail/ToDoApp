using Ninject;
using ToDoApp.Ninject.Modules;

namespace ToDoApp.Ninject.Factories
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }

    }
}
