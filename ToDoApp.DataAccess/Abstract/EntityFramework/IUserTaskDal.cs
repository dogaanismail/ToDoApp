using ToDoApp.Core.DataAccess.Abstract;
using ToDoApp.Entities.EntityFramework;

namespace ToDoApp.DataAccess.Abstract.EntityFramework
{
    public interface IUserTaskDal : IEntityRepository<UserTasks>
    {
    }
}
