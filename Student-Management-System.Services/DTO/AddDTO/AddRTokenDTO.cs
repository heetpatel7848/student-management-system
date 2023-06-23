using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services.DTO.AddDTO
{
    public class AddRTokenDTO
    {
        public string RefreshToken { get; set; }
        public bool IsStop { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
    }
}
