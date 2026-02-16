using System.ComponentModel.DataAnnotations;

namespace AppSTMS.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        
        

        [Required, EmailAddress]
        public string Email { get; set; }
        
        
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<TeamMember>? TeamMember { get; set; }
        
    }
}
