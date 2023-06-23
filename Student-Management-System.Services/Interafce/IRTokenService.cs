using Student_Management_System.Services.DTO;
using Student_Management_System.Services.DTO.GetDTO;

namespace Student_Management_System.Services.Interafce
{
    public interface IRTokenService
    {
        GetRTokenDTO IsUserExist(LoginDTO user);
        string GetRoleName(int userId);
    }
}
