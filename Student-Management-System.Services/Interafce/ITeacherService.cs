using Student_Management_System.Services.DTO;
using Student_Management_System.Services.DTO.AddDTO;
using Student_Management_System.Services.DTO.UpdateDTO;

namespace Student_Management_System.Services.Interafce
{
    public interface ITeacherService
    {
        ResponseDTO GetTeacher();
        ResponseDTO GetTeacherPaginated(int page, int limit);
        ResponseDTO GetTeacherById(int id);
        ResponseDTO GetTeacherByEmail(string email);
        ResponseDTO AddTeacher(AddTeacherDTO teacher);
        ResponseDTO UpdateTeacher(UpdateTeacherDTO teacher);
        ResponseDTO DeleteTeacher(int id);
    }
}
