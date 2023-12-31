﻿using Student_Management_System.Models.Interface;

namespace Student_Management_System.Models.Repository
{
    public class AdminRepository : IAdminRepository
    {
        #region Fields
        private readonly StudentSystemContext _context;
        #endregion


        #region Constructor
        public AdminRepository(StudentSystemContext context)
        {
            _context = context;
        }



        #endregion

        #region Methods
        public int AddAdmin(Admin admin)
        {
            _context.Add(admin);
            admin.IsActive = true;
            if (_context.SaveChanges() > 0)
                return admin.Id;
            else
                return 0;
        }

        public bool DeleteAdmin(Admin admin)
        {
            _context.Entry(admin).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Admin> GetAdmin()
        {
            return _context.Admins.Where(u => u.IsActive == true).ToList();
        }

        public Admin GetAdminByEmail(string email)
        {
            return _context.Admins.FirstOrDefault(u => u.Email == email && u.IsActive == true);
        }

        Admin IAdminRepository.GetAdminById(int id)
        {
            return _context.Admins.FirstOrDefault(u => u.Id == id && u.IsActive == true);
        }

        public IEnumerable<Admin> GetAdminPaginated(int page, int limit)
        {
            return _context.Admins.Where(u => u.IsActive == true).Skip((page - 1) * limit).Take(limit).ToList();
        }

        public bool UpdateAdmin(Admin admin)
        {
            var adminToUpdate = _context.Admins.Find(admin.Id);
            if (adminToUpdate == null)
            {
                return false;
            }

            adminToUpdate.Name = admin.Name;
            adminToUpdate.Email = admin.Email;
            adminToUpdate.Password = admin.Password;

            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}
