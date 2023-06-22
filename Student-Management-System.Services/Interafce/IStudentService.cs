using Student_Management_System.Services.DTO.AddDTO;
using Student_Management_System.Services.DTO.UpdateDTO;
using Student_Management_System.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services.Interafce
{
    public interface IStudentService
    {
        ResponseDTO GetStudent();
        ResponseDTO GetStudentPaginated(int page, int limit);
        ResponseDTO GetStudentByEmail(string email);
        ResponseDTO GetStudentById(int id);
        ResponseDTO AddStudent(AddStudentDTO student);
        ResponseDTO UpdateStudent(UpdateStudentDTO student);
        ResponseDTO DeleteStudent(int id);
    }
}
