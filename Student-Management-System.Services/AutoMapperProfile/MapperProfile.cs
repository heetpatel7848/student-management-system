using AutoMapper;
using Student_Management_System.Models;
using Student_Management_System.Services.DTO;
using Student_Management_System.Services.DTO.AddDTO;
using Student_Management_System.Services.DTO.GetDTO;
using Student_Management_System.Services.DTO.UpdateDTO;


namespace Student_Management_System.Services.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<UserDTO, User>();
            #endregion



            #region Teacher
            CreateMap<Teacher, GetTeacherDTO>();
            CreateMap<AddTeacherDTO, Teacher>();
            CreateMap<UpdateTeacherDTO, Teacher>();
            #endregion

            #region Student
            CreateMap<Student, GetStudentDTO>();
            CreateMap<AddStudentDTO, Student>();
            CreateMap<UpdateStudentDTO, Student>();
            #endregion


        }
    }
}
