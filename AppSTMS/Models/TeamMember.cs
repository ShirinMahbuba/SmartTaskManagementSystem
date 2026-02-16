using System.ComponentModel.DataAnnotations;

namespace AppSTMS.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        [Required]

        public int AppUserId { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        [StringLength(30)]
        public string? Designation { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [ StringLength(30)]
        public string? Mobile { get; set; }

        public bool IsActive { get; set; }
        public List<ProjectTask>? ProjectTask { get; set; }
        public List<TaskComments>? TaskComments { get; set; }

    }
}
