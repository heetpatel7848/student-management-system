using Student_Management_System.Services.DTO;
using Student_Management_System.Services.DTO.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services.Interafce
{
    public interface IUserService
    {
        //ResponseDTO GetUser();
        ResponseDTO GetUserByEmail(string email);
        //ResponseDTO GetUserById(int id);
        ResponseDTO AddUser(UserDTO user);
        ResponseDTO UpdateUser(UserDTO user);
        //ResponseDTO DeleteUser(int id);
        GetUserDTO IsUserExists(UserDTO user);
        string AddRole(int userId);
    }
}
