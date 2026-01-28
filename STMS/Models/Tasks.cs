using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STMS.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        [ForeignKey("Priority")]
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        [ForeignKey("CreatedByUser")]
        public int CreatedBy{ get; set; }
        public Users CreatedByUser { get; set; }
        [ForeignKey("TaskStatus")]
        public string StatusId { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public DateTime? CompletedAt { get; set; }

        public ICollection<TaskAssignment> TaskAssignments { get; set; }
        public ICollection<TaskComment> TaskComments { get; set; }
        public ICollection<TaskAttachment> TaskAttachments { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<TaskDependency> ParentDependencies { get; set; } 
        public ICollection<TaskDependency> DependentDependencies { get; set; } 
        public ICollection<TaskDiscussion> TaskDiscussions { get; set; }
        public ICollection<ActivityLog> ActivityLogs { get; set; }
    }
}

