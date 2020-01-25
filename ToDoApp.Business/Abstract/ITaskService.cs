using System.Collections.Generic;
using ToDoApp.Entities.EntityFramework;

namespace ToDoApp.Business.Abstract
{
    public interface ITaskService
    {
        /// <summary>
        /// Return tasks lists.
        /// </summary>
        /// <returns></returns>
        List<Tasks> GetTasks();

        /// <summary>
        /// Return a single task by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Tasks GetById(int id);

        /// <summary>
        /// Creates a task.
        /// </summary>
        /// <param name="task"></param>
        void Create(Tasks task);

        /// <summary>
        /// Updates a task.
        /// </summary>
        /// <param name="task"></param>
        void Update(Tasks task);

        /// <summary>
        /// Deletes a task.
        /// </summary>
        /// <param name="task"></param>
        void Delete(Tasks task);
    }
}
