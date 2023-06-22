namespace Student_Management_System.Services.DTO.UpdateDTO
{
    public class UpdateAdminDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
