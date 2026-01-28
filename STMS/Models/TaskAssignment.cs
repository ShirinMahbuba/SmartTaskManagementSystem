using System.ComponentModel.DataAnnotations.Schema;

namespace STMS.Models
{
    public class TaskAssignment
    {
        public int Id { get; set; }
        [ForeignKey("Tasks")]
        public int TaskId { get; set; }
        public Tasks Task { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public Users User { get; set; }
    }
}
