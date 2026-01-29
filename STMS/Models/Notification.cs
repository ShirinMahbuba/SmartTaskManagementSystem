namespace STMS.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }

        public int TaskId { get; set; }
        public Tasks Task { get; set; }

        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
