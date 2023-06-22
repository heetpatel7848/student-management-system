namespace Student_Management_System.Models.Interface
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudent();
        int AddStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        IEnumerable<Student> GetStudentPaginated(int page, int limit);
        Student GetStudentById(int id);
        Student GetStudentByEmail(string email);
    }
}
