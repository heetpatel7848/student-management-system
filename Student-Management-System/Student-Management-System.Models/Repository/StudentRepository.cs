using Student_Management_System.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        #region Fields
        private readonly StudentSystemContext _context;
        #endregion


        #region Methods
        public StudentRepository(StudentSystemContext context)
        {
            _context = context;
        }


        #endregion

        #region Methods
        //public int AddStudent(Student student)
        //{
        //    _context.Add(student);
        //    student.Role = "student";
        //    if (_context.SaveChanges() > 0)
        //        return student.Id;
        //    else
        //        return 0;
        //}

        public int AddStudent(Student student)
        {
            student.Role = "student"; // Set the role before saving changes
            _context.Add(student);

            if (_context.SaveChanges() > 0)
                return student.Id;
            else
                return 0;
        }




        public bool DeleteStudent(Student student)
        {
            _context.Entry(student).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Student> GetStudent()
        {
            return _context.Students.Where(u => u.IsActive == true).ToList();
        }

        public Student GetStudentByEmail(string email)
        {
            return _context.Students.FirstOrDefault(u => u.Email == email && u.IsActive == true);
        }

        Student IStudentRepository.GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(u => u.Id == id && u.IsActive == true);
        }

        public IEnumerable<Student> GetStudentPaginated(int page, int limit)
        {
            return _context.Students.Where(u => u.IsActive == true).Skip((page - 1) * limit).Take(limit).ToList();

        }

        public bool UpdateStudent(Student student)
        {
            _context.Entry(student).Property("Name").IsModified = true;
            _context.Entry(student).Property("Class").IsModified = true;
            _context.Entry(student).Property("RollNo").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        #endregion

    }


}
