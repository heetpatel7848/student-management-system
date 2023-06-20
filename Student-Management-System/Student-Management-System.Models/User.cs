using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_System.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        
        public string Password { get; set; }
        
        [ForeignKey("roleId")]
        public string? RoleId { get; set; }

        public virtual Role Role { get; set; }

        public  bool IsActive { get; set; }
    }
}