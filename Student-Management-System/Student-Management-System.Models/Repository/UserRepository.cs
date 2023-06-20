﻿using Student_Management_System.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        #region fields
        private readonly StudentSystemContext _context;
        #endregion

        #region Constructor
        public UserRepository(StudentSystemContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods
        public int AddUser(User user)
        {
            _context.Add(user);
            return _context.SaveChanges();
        }

        public bool DeleteUser(User user)
        {
            _context.Users.Remove(user);
            return _context.SaveChanges() > 0;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.IsActive == true);
        }

        public User GetUserById(int Id)
        {
            return _context.Users.FirstOrDefault(u=> u.Id == Id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}