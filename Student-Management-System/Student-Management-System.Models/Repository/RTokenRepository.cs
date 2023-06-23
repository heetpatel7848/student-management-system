using Student_Management_System.Models.Interface;

namespace Student_Management_System.Models.Repository
{
    public class RTokenRepository : IRTokenRepository
    {
        #region Fields
        private readonly StudentSystemContext _context;
        #endregion

        #region Constructor
        public RTokenRepository(StudentSystemContext context)
        {
            _context = context;
        }


        #endregion

        #region Methods
        public int AddStudent(User student)
        {
            _context.Add(student);
            if (_context.SaveChanges() > 0)
                return student.Id;
            else
                return 0;
        }

        public int AddTeacher(User teacher)
        {
            _context.Add(teacher);
            if (_context.SaveChanges() > 0)
                return teacher.Id;
            else
                return 0;
        }

        public string GetRoleName(int userId)
        {
            var result = _context.Users.FirstOrDefault(u => u.Id == userId);
            return result.Role;
        }

        public User GetUserByEmail(string email)
        {
           return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        #endregion
    }
}
