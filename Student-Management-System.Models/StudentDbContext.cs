using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;

namespace Student_Management_System.Context
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
