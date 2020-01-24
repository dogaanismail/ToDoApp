namespace ToDoApp.Entities.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserTasks> UserTasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserTasks)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.BelongsTo);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserTasks1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.CreatedBy);
        }
    }
}
