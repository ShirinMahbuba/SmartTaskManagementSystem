using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppSTMS.Models;

namespace AppSTMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppSTMS.Models.AppUser> AppUser { get; set; } = default!;
        public DbSet<AppSTMS.Models.Project> Project { get; set; } = default!;
        public DbSet<AppSTMS.Models.ProjectTeam> ProjectTeam { get; set; } = default!;
        public DbSet<AppSTMS.Models.ProjectTask> ProjectTask { get; set; } = default!;
        public DbSet<AppSTMS.Models.ProjectTaskStatus> ProjectTaskStatus { get; set; } = default!;
        public DbSet<AppSTMS.Models.TaskAttachments> TaskAttachments { get; set; } = default!;
        public DbSet<AppSTMS.Models.TaskComments> TaskComments { get; set; } = default!;
        public DbSet<AppSTMS.Models.TaskDependency> TaskDependency { get; set; } = default!;
        public DbSet<AppSTMS.Models.TaskPriority> TaskPriority { get; set; } = default!;
        public DbSet<AppSTMS.Models.TeamMember> TeamMember { get; set; } = default!;
    }
}
