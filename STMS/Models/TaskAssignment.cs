namespace STMS.Models
{
    public class TaskAssignment
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public Tasks Task { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }
    }
}
