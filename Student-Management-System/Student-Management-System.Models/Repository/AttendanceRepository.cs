using Student_Management_System.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        #region Fields
        private readonly StudentSystemContext _context;
        #endregion


        #region Constructor
        public AttendanceRepository(StudentSystemContext context)
        {
            _context = context;
        }


        #endregion

        #region Methods
        public int AddAttendance(Attendance attendance)
        {
            _context.Add(attendance);
            if (_context.SaveChanges() > 0)
                return attendance.Id;
            else
                return 0;
        }

        public bool DeleteAttendance(Attendance attendance)
        {
            _context.Entry(attendance).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Attendance> GetAttendance()
        {
            return _context.Attendances.Where(a => a.IsActive == true).ToList();
        }

        public Attendance GetAttendanceById(int teacherId, int studentId)
        {
            return _context.Attendances.FirstOrDefault(a => a.TeacherId == teacherId && a.StudentId == studentId && a.IsActive == true);
        }

        public Attendance GetAttendanceByStudentId(int Id)
        {
            return _context.Attendances.FirstOrDefault(u => u.Id == Id  && u.IsActive == true);
        }



        //Attendance IAttendanceRepository.GetAttendanceById(int Id)
        //{
        //    return _context.Attendances.Where(a => a.StudentId == Id && a.IsActive == true).ToList();
        //}

        public IEnumerable<Attendance> GetAttendanceByTeacherId(int teacherId)
        {
            return _context.Attendances.Where(a => a.TeacherId == teacherId && a.IsActive == true).ToList();
        }

        public IEnumerable<Attendance> GetAttendancePaginated(int page, int limit)
        {
            return _context.Attendances.Where(a => a.IsActive == true).Skip((page - 1) * limit).Take(limit).ToList();
        }

        public bool UpdateAttendance(Attendance attendance)
        {
            _context.Entry(attendance).Property("Name").IsModified = true;
            _context.Entry(attendance).Property("Date").IsModified = true;
            _context.Entry(attendance).Property("Subject").IsModified = true;
            _context.Entry(attendance).Property("IsPresent").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        #endregion

    }
}
