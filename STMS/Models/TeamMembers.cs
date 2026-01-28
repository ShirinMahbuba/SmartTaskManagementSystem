using System.ComponentModel.DataAnnotations.Schema;

namespace STMS.Models
{
    public class TeamMembers
    {
        public int Id { get; set; }
        [ForeignKey("Teams")]
        public int TeamId { get; set; }
        public Teams Team { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public Users User { get; set; }
    }
}
