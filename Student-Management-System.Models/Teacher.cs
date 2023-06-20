using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_System
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public DateTime DOB { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime EnrollmentDate { get; set; }
        public string Qualification { get; set; }
        public bool IsTeacher { get; set; }
    }
}
