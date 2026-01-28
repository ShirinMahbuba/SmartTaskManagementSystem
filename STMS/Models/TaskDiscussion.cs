using System.ComponentModel.DataAnnotations.Schema;

namespace STMS.Models
{
    public class TaskDiscussion
    {
        public int Id { get; set; }
        [ForeignKey("Tasks")]
        public int TaskId { get; set; }
        public Tasks Task { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Teams Team { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public Users User { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
    }
}
