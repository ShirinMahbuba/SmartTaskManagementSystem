using System.ComponentModel.DataAnnotations;

namespace AppSTMS.Models
{
    public class TaskComments
    {
        public int Id { get; set; }
        [Required, Display(Name = "ProjectTask")]
        public int ProjectTaskId { get; set; }

        [Required, Display(Name = "Team Member")]
        public int ProjectTeamId { get; set; }

        [Required]

        public string Remarks { get; set; }
        [Required, Display(Name = "Post Time")]
        public DateTime PostTime { get; set; }

        public ProjectTask? ProjectTasks { get; set; }
        public ProjectTeam? ProjectTeam { get; set; }
    }
}
