namespace ToDoApp.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using ToDoApp.Core.Entities;

    public partial class UserTasks : IEntity
    {
        [Key]
        public int UserTaskId { get; set; }

        public int? TaskId { get; set; }

        [StringLength(128)]
        public string CreatedBy { get; set; }

        [StringLength(128)]
        public string BelongsTo { get; set; }

        public virtual Tasks Tasks { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
