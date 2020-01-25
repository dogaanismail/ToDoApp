using ToDoApp.Entities.EntityFramework;

namespace ToDoApp.Business.Abstract
{
    public interface IUserTaskService
    {
        /// <summary>
        /// Creates a user task.
        /// </summary>
        /// <param name="tasks"></param>
        void Create(UserTasks tasks);

        //Updates a user task.
        void Update(UserTasks tasks);

        //Deletes a user task.
        void Delete(UserTasks tasks);
    }
}
