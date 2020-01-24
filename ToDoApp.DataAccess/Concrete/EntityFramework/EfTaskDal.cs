using ToDoApp.Core.DataAccess.Concrete.EntityFramework;
using ToDoApp.DataAccess.Abstract.EntityFramework;
using ToDoApp.Entities.EntityFramework;

namespace ToDoApp.DataAccess.Concrete.EntityFramework
{
    public class EfTaskDal :  EfEntityRepositoryBase<Tasks, ApplicationContext>, ITaskDal
    {
    }
}
