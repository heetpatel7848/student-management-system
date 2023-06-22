using Student_Management_System.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        #region Fields
        private readonly StudentSystemContext _context;
        #endregion


        #region Constructor
        public TeacherRepository(StudentSystemContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods
        public int AddTeacher(Teacher teacher)
        {
            _context.Add(teacher);
            teacher.Role = "teacher";
            if (_context.SaveChanges() > 0)
                return teacher.Id;
            else
                return 0;
        }

        public bool DeleteTeacher(Teacher teacher)
        {
            _context.Entry(teacher).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Teacher> GetTeacher()
        {
            return _context.Teachers.Where(u => u.IsActive == true).ToList();
        }

        public Teacher GetTeacherByEmail(string email)
        {
            return _context.Teachers.FirstOrDefault(u => u.Email == email && u.IsActive == true);

        }



        public IEnumerable<Teacher> GetTeacherPaginated(int page, int limit)
        {
            return _context.Teachers.Where(u => u.IsActive == true).Skip((page - 1) * limit).Take(limit).ToList();
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            _context.Entry(teacher).Property("Name").IsModified = true;
            _context.Entry(teacher).Property("MobileNo").IsModified = true;
            _context.Entry(teacher).Property("Email").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        Teacher ITeacherRepository.GetTeacherById(int id)
        {
            return _context.Teachers.FirstOrDefault(u => u.Id == id && u.IsActive == true);
        }
        #endregion


    }
}
