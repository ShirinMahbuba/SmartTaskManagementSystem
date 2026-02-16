using System.ComponentModel.DataAnnotations;

namespace AppSTMS.Models
{
    public class TaskAttachments
    {
        public int Id { get; set; }
        [Required,Display(Name = "ProjectTask")]
        public int ProjectTaskId { get; set; }
        [Required, StringLength(150)]
        public string AttFileName { get; set; }

        [Required]

        public string Remarks { get; set; }
        
        public ProjectTask? ProjectTasks { get; set; }
    }
}
