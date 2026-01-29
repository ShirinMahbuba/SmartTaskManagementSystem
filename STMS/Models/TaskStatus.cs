using System.ComponentModel.DataAnnotations;

namespace STMS.Models
{
    public class TaskStatus
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
    }
}
