using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services.DTO.GetDTO
{
    public class GetTeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public string Qualification { get; set; }
        public int Salary { get; set; }
        public DateTime DOB { get; set; }
        public DateTime EnrollmentDate { get; set; }


    }
}
