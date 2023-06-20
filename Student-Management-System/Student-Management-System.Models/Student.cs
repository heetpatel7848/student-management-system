using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string RollNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string Password { get; set; }
        public bool IsStudent { get; set; }
    }
}
