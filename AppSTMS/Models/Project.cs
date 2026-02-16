using System.ComponentModel.DataAnnotations;

namespace AppSTMS.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string ProjectTitle { get; set; }
        public string PlanStartDate { get; set; }
        public string PlanEndDate { get; set; }


        public bool IsActive { get; set; }
        public List<ProjectTask>? ProjectTasks { get; set; }
        public List<TeamMember>? TeamMembers { get; set; }
    }
}
