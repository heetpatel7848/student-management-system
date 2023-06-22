namespace Student_Management_System.Models.Interface
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> GetAdmin();
        int AddAdmin(Admin admin);
        bool UpdateAdmin(Admin admin);
        bool DeleteAdmin(Admin admin);
        IEnumerable<Admin> GetAdminPaginated(int page, int limit);
        Admin GetAdminById(int id);
        Admin GetAdminByEmail(string email);
    }
}
