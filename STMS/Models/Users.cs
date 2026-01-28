using System.ComponentModel.DataAnnotations;

namespace STMS.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required,MaxLength(255)]
        public string FirstName { get; set; }
        [Required,MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        public string PasswordHash{ get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        public ICollection<UserRoles> UserRoles { get; set; }
        public ICollection<TaskAssignment> TaskAssignments { get; set; }
        public ICollection<Task> CreatedTasks { get; set; }
        public ICollection<TaskComment> TaskComments { get; set; }
        public ICollection<TaskAttachment> TaskAttachments { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<TaskDiscussion> TaskDiscussions { get; set; }
        public ICollection<ActivityLog> ActivityLogs { get; set; }
        public ICollection<TeamMembers> TeamMembers { get; set; }
        public ICollection<Teams> CreatedTeams { get; set; }







    }
}
