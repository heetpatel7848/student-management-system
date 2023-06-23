using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models.Interface
{
    public interface IRTokenRepository
    {
        int AddTeacher(User teacher);
        int AddStudent(User student);
        User GetUserByEmail(string email);
        string GetRoleName(int userId);
    }
}
