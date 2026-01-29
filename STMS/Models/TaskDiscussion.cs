namespace STMS.Models
{
    public class TaskDiscussion
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public Tasks Task { get; set; }

        public int TeamId { get; set; }
        public Teams Team { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }

        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
