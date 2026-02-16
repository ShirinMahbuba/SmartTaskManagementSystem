using System.ComponentModel.DataAnnotations;

namespace AppSTMS.Models
{
    public class TaskDependency
    {
        public int Id { get; set; }
        [Required, Display(Name = "ProjectTask")]
        public int ProjectTaskId { get; set; }
       
        [Required, Display(Name = "Depends On ProjectTask")]
        public int  DependsOnTaskId { get; set; }

        [Required]

        public string Remarks { get; set; }

        public ProjectTask? ProjectTasks { get; set; }
        public ProjectTask? DependsOnTask { get; set; }
    }
}
