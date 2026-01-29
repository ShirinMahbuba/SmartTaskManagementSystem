using System.ComponentModel.DataAnnotations;

namespace STMS.Models
{
    public class TaskAttachment
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public Tasks Task { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }

        public string FileName { get; set; }

        [Required]
        public string FilePath { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
