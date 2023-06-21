using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById (int id);

        User GetUserByEmail(string email);
        int AddUser (User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);

    }
}
