﻿using System;

namespace ToDoApp.DataDomain.Api
{
    public class TaskApi
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? Deadline { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
