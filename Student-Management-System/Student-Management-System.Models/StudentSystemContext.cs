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
        public DbSet<Role> Roles { get; set; }
        public DbSet<RToken> RTokens { get; set; }
    }
}
