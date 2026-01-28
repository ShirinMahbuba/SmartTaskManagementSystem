using System.ComponentModel.DataAnnotations;

namespace STMS.Models
{
    public class Teams
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int CreatedBy { get; set; }
        public Users CreatedByUser { get; set; }
        public ICollection<TeamMembers> TeamMembers { get; set; }
        public ICollection<TaskDiscussion> TaskDiscussion { get; set; }

    }
}
