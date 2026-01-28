using System.ComponentModel.DataAnnotations.Schema;

namespace STMS.Models
{
    public class TaskDependency
    {
        public int Id { get; set; }
        [ForeignKey("ParentTask")]
        public int ParentTaskId { get; set; }
        public Tasks ParentTask { get; set; }
        [ForeignKey("DependentTask")]
        public int DependentTaskId { get; set; }
        public Tasks DependentTask { get; set; }
    }
}
