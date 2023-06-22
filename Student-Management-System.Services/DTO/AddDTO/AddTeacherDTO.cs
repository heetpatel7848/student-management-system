using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_System.Services.DTO.AddDTO
{
    public class AddTeacherDTO
    {
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Name cannot be greater than 30 Characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        [MaxLength(64, ErrorMessage = "Email address can not be longer than {1} characters")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Password should be {2} to {1} characters long")]
        public string Password { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public DateTime DOB { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EnrollmentDate { get; set; }
        public string Qualification { get; set; }
        public int Salary { get; set; }
        public bool? IsActive { get; set; }
    }
}
