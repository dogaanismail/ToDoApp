using Ninject.Modules;
using ToDoApp.Business.Abstract;
using ToDoApp.Business.Concrete.Managers;
using ToDoApp.DataAccess.Abstract.EntityFramework;
using ToDoApp.DataAccess.Concrete.EntityFramework;

namespace ToDoApp.Ninject.Modules
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITaskService>().To<TaskManager>().InSingletonScope();
            Bind<ITaskDal>().To<EfTaskDal>().InSingletonScope();

            Bind<IUserTaskService>().To<UserTaskManager>().InSingletonScope();
            Bind<IUserTaskDal>().To<EfUserTaskDal>().InSingletonScope();
        }
    }
}
