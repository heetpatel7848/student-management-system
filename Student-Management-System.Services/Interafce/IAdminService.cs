using Student_Management_System.Services.DTO;
using Student_Management_System.Services.DTO.AddDTO;
using Student_Management_System.Services.DTO.UpdateDTO;

namespace Student_Management_System.Services.Interafce
{
    public interface IAdminService
    {
        ResponseDTO GetAdmin();
        ResponseDTO GetAdminPaginated(int page, int limit);
        ResponseDTO GetAdminByEmail(string email);
        ResponseDTO GetAdminById(int id);
        ResponseDTO AddAdmin(AddAdminDTO admin);
        ResponseDTO UpdateAdmin(UpdateAdminDTO admin);
        ResponseDTO DeleteAdmin(int id);
    }
}
