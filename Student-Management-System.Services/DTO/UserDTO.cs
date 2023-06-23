using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services.DTO
{
    public class UserDTO
    {
        internal bool IsActive;


        public string? Email { get; set; }

        public string Password { get; set; }

        [ForeignKey("roleId")]
        public string? RoleId { get; set; }
        //bool IsUserExist(LoginDTO user);

    }
}
