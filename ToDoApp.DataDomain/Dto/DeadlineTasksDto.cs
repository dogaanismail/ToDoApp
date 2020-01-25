using System.Collections.Generic;

namespace ToDoApp.DataDomain.Dto
{
    public class DeadlineTasksDto
    {
        public List<TaskDto> DeadlineTasks { get; set; }
        public string Message { get; set; }
    }
}
