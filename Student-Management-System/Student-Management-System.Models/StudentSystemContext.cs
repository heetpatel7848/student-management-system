using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext(DbContextOptions<StudentSystemContext>options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<RToken> RTokens { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}
