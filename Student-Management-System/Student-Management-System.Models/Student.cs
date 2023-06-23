using System.ComponentModel.DataAnnotations;
namespace Student_Management_System.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }
        public int RollNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string Password { get; set; }
        //public string Role { get; set; }
        public bool? IsActive { get; set; }
    }
}
