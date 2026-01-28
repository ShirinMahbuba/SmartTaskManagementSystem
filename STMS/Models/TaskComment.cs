using System.ComponentModel.DataAnnotations.Schema;

namespace STMS.Models
{
    public class TaskComment
    {
        public int Id { get; set; }
        [ForeignKey("Tasks")]
        public int TaskId { get; set; }
        public Tasks Task { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public Users User { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
