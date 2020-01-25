namespace ToDoApp.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using ToDoApp.Core.Entities;

    public partial class Tasks : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tasks()
        {
            UserTasks = new HashSet<UserTasks>();
        }

        [Key]
        public int TaskId { get; set; }

        [StringLength(150)]
        public string TaskName { get; set; }

        [StringLength(150)]
        public string TaskTitle { get; set; }

        [StringLength(500)]
        public string TaskDescription { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? Deadline { get; set; }

        public bool? IsCompleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTasks> UserTasks { get; set; }
    }
}
