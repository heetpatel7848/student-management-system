namespace Student_Management_System.Services.DTO.AddDTO
{
    public class AddStudentDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }
        public string RollNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string Password { get; set; }
        //public string? Role { get; set; }
        public bool? IsActive { get; set; }
    }
}
