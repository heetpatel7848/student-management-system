using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services.DTO.AddDTO
{
    public class AddStudentDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }
        public string RollNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string Password { get; set; }
        public bool IsStudent { get; set; }
        public string? Role { get; set; }
        public bool? IsActive { get; set; }
    }
}
