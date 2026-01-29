namespace STMS.Models
{
    public class TaskComment
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public Tasks Task { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }

        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
