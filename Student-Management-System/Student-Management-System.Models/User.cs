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
        public string? Role { get; set; }
        public  bool IsActive { get; set; }
        public string? Class { get; set; }
        public string? Subject { get; set; }
        public DateTime? DOB { get; set; }

        public DateTime? EnrollmentDate { get; set; }
        public int? Salary { get; set; }
        public string? Qualification { get; set; }

    }
}