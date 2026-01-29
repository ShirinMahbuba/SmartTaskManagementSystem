using System.ComponentModel.DataAnnotations;

namespace STMS.Models
{
    public class Roles
    {
        public int Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
