using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services.DTO.GetDTO
{
    public class GetAttendanceDTO
    {
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
    }
}
