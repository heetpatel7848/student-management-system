namespace Student_Management_System.Services.DTO.AddDTO
{
    public class AddAdminDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public  string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
