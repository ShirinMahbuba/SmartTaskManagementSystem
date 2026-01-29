using Microsoft.EntityFrameworkCore;
using STMS.Models;
using TaskStatusEntity = STMS.Models.TaskStatus;

namespace STMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskStatusEntity> TaskStatuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }
        public DbSet<TaskAttachment> TaskAttachments { get; set; }
        public DbSet<TaskDependency> TaskDependencies { get; set; }
        public DbSet<TaskDiscussion> TaskDiscussions { get; set; }

        public DbSet<Teams> Teams { get; set; }
        public DbSet<TeamMembers> TeamMembers { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskDependency>()
                .HasOne(td => td.ParentTask)
                .WithMany(t => t.ParentDependencies)
                .HasForeignKey(td => td.ParentTaskId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskDependency>()
                .HasOne(td => td.DependentTask)
                .WithMany(t => t.DependentDependencies)
                .HasForeignKey(td => td.DependentTaskId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
