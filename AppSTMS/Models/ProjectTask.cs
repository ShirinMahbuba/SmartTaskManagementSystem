using System.ComponentModel.DataAnnotations;

namespace AppSTMS.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        [Required, Display(Name = "Project")]
        public int ProjectId { get; set; }

       [Required, Display(Name = "Task Name")]
        public string TaskName { get; set; }

        [Required, Display(Name = "Task Description")]
        public string TaskDesc { get; set; }

        [Required, Display(Name = "Assigned To")]
        public int TeamMemberId { get; set; }

        [Required, Display(Name = " ProjectTask Status")]
        public int ProjectTaskStatusId { get; set; }
        [Required, Display(Name = "Priority Level")]

        public int TaskPriorityId  { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        public DateTime CompletedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public int CompletedBy { get; set; }

        public ProjectTaskStatus? ProjectTaskStatus { get; set; }

        public TaskPriority? TaskPriority { get; set; }
         public TeamMember? TeamMember { get; set; }
         
         
         public Project?  Project { get; set; }






    }
}
