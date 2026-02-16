using System.ComponentModel.DataAnnotations;

namespace AppSTMS.Models
{
    public class ProjectTeam
    {
        public int Id { get; set; }
        [Required,Display(Name ="Project")]
        public int ProjectId { get; set; }
        [Required, Display(Name = "Team Member")]
        public string TeamMemberId { get; set; }
       
    }
}
