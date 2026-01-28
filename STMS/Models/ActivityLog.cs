using System.ComponentModel.DataAnnotations.Schema;

namespace STMS.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }
        [ForeignKey("Tasks")]
        public int TaskId { get; set; }
        public Tasks Task { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public Users User { get; set; }
        public string Action { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
