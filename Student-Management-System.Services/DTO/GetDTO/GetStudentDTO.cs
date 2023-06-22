using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services.DTO.GetDTO
{
    public class GetStudentDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }
        public int RollNo { get; set; }

    }
}
