namespace STMS.Models
{
    public class TeamMembers
    {
        public int Id { get; set; }

        public int TeamId { get; set; }
        public Teams Team { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }
    }
}
