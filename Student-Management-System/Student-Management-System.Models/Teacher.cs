using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(50, ErrorMessage ="Name cannot be greater than 30 Characters")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public DateTime DOB { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EnrollmentDate { get; set; }
        public string Qualification { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }

    }
}
