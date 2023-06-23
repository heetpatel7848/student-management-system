namespace Student_Management_System.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public bool IsPresent { get; set; }
        public DateTime Date { get; set; }
        public bool? IsActive { get; set; }

    }
}
