namespace STMS.Models
{
    public class TaskDependency
    {
        public int Id { get; set; }

        public int ParentTaskId { get; set; }
        public Tasks ParentTask { get; set; }

        public int DependentTaskId { get; set; }
        public Tasks DependentTask { get; set; }
    }
}
