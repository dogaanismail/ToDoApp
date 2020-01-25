using System;

namespace ToDoApp.DataDomain.ViewModels
{
    public class TasksViewModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? Deadline { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
