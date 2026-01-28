using System.ComponentModel.DataAnnotations.Schema;

namespace STMS.Models
{
    public class UserRoles
    {
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public Users User { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        public Roles Role { get; set; }
    }
}
