using System.Collections.Generic;
using ToDoApp.Business.Abstract;
using ToDoApp.Core.Aspects.PostsSharp.CacheAspects;
using ToDoApp.Core.Aspects.PostsSharp.PerformanceAspects;
using ToDoApp.Core.CrossCuttingConcers.Caching.Microsoft;
using ToDoApp.DataAccess.Abstract.EntityFramework;
using ToDoApp.Entities.EntityFramework;

namespace ToDoApp.Business.Concrete.Managers
{
    public class TaskManager : ITaskService
    {
        #region Ctor
        private ITaskDal _taskDal;

        public TaskManager(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }

        #endregion

        [CacheAspect(typeof(MemoryCacheManager), 30)]
        public Tasks GetById(int id)
        {
            return _taskDal.Get(x => x.TaskId == id);
        }

        [CacheAspect(typeof(MemoryCacheManager), 30)]
        [PerformanceCounterAspect]
        public List<Tasks> GetTasks()
        {
            return _taskDal.GetList();
        }

        public void Update(Tasks task)
        {
            _taskDal.Update(task);
        }

        public void Create(Tasks task)
        {
            _taskDal.Add(task);
        }

        public void Delete(Tasks task)
        {
            _taskDal.Delete(task);
        }
    }
}
