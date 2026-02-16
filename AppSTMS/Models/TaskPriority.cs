using System.ComponentModel.DataAnnotations;

namespace AppSTMS.Models
{
    public class TaskPriority
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string PriorityName { get; set; }

        public bool IsActive { get; set; }
        public List<ProjectTask>? ProjectTasks { get; set; }
    }
}
