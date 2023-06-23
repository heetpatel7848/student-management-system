using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models.Interface
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetAttendance();
        int AddAttendance(Attendance attendance);
        bool UpdateAttendance(Attendance attendance);
        IEnumerable<Attendance> GetAttendanceByStudentId(int studentId);
        IEnumerable<Attendance> GetAttendanceByTeacherId(int teacherId);
        IEnumerable<Attendance> GetAttendancePaginated(int page, int limit);

    }
}
