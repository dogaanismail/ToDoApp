using ToDoApp.Business.Abstract;
using ToDoApp.DataAccess.Abstract.EntityFramework;
using ToDoApp.Entities.EntityFramework;

namespace ToDoApp.Business.Concrete.Managers
{
    public class UserTaskManager : IUserTaskService
    {
        #region Ctor
        private readonly IUserTaskDal _userTaskDal;
        public UserTaskManager(IUserTaskDal userTaskDal)
        {
            _userTaskDal = userTaskDal;
        }
        #endregion
        public void Create(UserTasks tasks)
        {
            _userTaskDal.Add(tasks);
        }

        public void Delete(UserTasks tasks)
        {
            _userTaskDal.Delete(tasks);
        }

        public void Update(UserTasks tasks)
        {
            _userTaskDal.Update(tasks);
        }
    }
}
