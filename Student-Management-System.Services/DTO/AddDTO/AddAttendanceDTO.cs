using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services.DTO.AddDTO
{
    public class AddAttendanceDTO
    {
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public bool IsPresent { get; set; }
    }
}
