using System.Collections.Generic;
using ToDoApp.Entities.EntityFramework;

namespace ToDoApp.Business.Abstract
{
    public interface ITaskService
    {
        List<Tasks> GetTasks();
    }
}
