namespace Student_Management_System.Models
{
    public class Admin
    {
        public int Id { get; set; }  
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get;set; }
        public bool? IsActive { get; set; }
    }
}
