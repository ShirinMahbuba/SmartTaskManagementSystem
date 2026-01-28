using System.ComponentModel.DataAnnotations.Schema;

namespace STMS.Models
{
    public class Notification
    {
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public Users User { get; set; }
        [ForeignKey("Tasks")]
        public int TaskId { get; set; }
        public Tasks Task { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}
