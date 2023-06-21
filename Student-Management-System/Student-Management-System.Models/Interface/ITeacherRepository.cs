﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models.Interface
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetTeacher();
        IEnumerable<Teacher> GetTeacherPaginated(int page, int limit);
        Teacher GetTeacherById(int id);
        Teacher GetTeacherByEmail(string email);
        int AddTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
        bool DeleteTeacher(Teacher teacher);
    }
}
