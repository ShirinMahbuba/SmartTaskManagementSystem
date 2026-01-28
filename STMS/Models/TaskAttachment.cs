using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STMS.Models
{
    public class TaskAttachment
    {
        public int Id { get; set; }
        [ForeignKey("Tasks")]
        public int TaskId { get; set; }
        public Tasks Task { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public Users User { get; set; }
        
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
