using System.Collections.Generic;
using ToDoApp.Business.Abstract;
using ToDoApp.DataAccess.Abstract.EntityFramework;
using ToDoApp.Entities.EntityFramework;

namespace ToDoApp.Business.Concrete.Managers
{
    public class TaskManager : ITaskService
    {
        private ITaskDal _taskDal;

        public TaskManager(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }

        public List<Tasks> GetTasks()
        {
            return _taskDal.GetList();
        }
    }
}
