using AutoMapper;
using Student_Management_System.Models;
using Student_Management_System.Models.Interface;
using Student_Management_System.Services.DTO;
using Student_Management_System.Services.DTO.AddDTO;
using Student_Management_System.Services.DTO.GetDTO;
using Student_Management_System.Services.DTO.UpdateDTO;
using Student_Management_System.Services.Interafce;

namespace Student_Management_System.Services.Services
{
    public class TeacherService : ITeacherService
    {
        #region Fileds
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IGradebookRepository _gradebookRepository;
        #endregion

        #region Constructor
        public TeacherService(IGradebookRepository gradebookRepository, ITeacherRepository teacherRepository, IAttendanceRepository attendanceRepository , IMapper mapper , IUserRepository userRepository)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _attendanceRepository = attendanceRepository;
            _gradebookRepository = gradebookRepository;
        }

        #endregion

        #region Methods
        public ResponseDTO AddTeacher(AddTeacherDTO teacher)
        {
            var response = new ResponseDTO();
            try
            {
                //var userByEmail = _teacherRepository.GetTeacherByEmail(teacher.Email);
                //if (userByEmail != null)
                //{
                //    response.Status = 400;
                //    response.Message = "Not Created";
                //    response.Error = "Email already exists";
                //    return response;
                //}

                var userId = _teacherRepository.AddTeacher(_mapper.Map<Teacher>(teacher));
                if (userId == 0)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add user";
                    return response;
                }


                response.Status = 201;
                response.Message = "Created";
                response.Data = userId;
                var user = new User()
                {
                    Email = teacher.Email,
                    Password = teacher.Password,
                    Role = "teacher",
                  
                    //Class = teacher.Class,
                    //Subject = teacher.Subject,
                    //DOB = teacher.DOB,
                    //EnrollmentDate = teacher.EnrollmentDate,
                    //Qualification = teacher.Qualification,
                    //Salary = teacher.Salary
                };

                _userRepository.AddUser(user);
                response.Status = 201;
                response.Message = "Created";
                response.Data = user;

            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO DeleteTeacher(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var teacherById = _teacherRepository.GetTeacherById(id);
                if (teacherById  == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                teacherById.IsActive = false;
                var deleteFlag = _teacherRepository.DeleteTeacher(teacherById);
                if (deleteFlag)
                {
                    response.Status = 204;
                    response.Message = "Deleted";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Could not delete user";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO GetTeacher()
        {
            var response = new ResponseDTO();
            try
            {
                var teachers = _teacherRepository.GetTeacher().ToList();
                var data = teachers.Select(teacher => new GetTeacherDTO
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    Email = teacher.Email,
                    Subject = teacher.Subject,
                    Class = teacher.Class,
                    Qualification = teacher.Qualification,
                    Salary = teacher.Salary,
                    DOB = teacher.DOB,
                    EnrollmentDate = teacher.EnrollmentDate
                }).ToList();

                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }


        public ResponseDTO GetTeacherById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var teacher = _teacherRepository.GetTeacherById(id);
                if (teacher == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }

                var data = new GetTeacherDTO
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    Email = teacher.Email,
                    Subject = teacher.Subject,
                    Class = teacher.Class,
                    Qualification = teacher.Qualification,
                    Salary = teacher.Salary,
                    DOB = teacher.DOB,
                    EnrollmentDate = teacher.EnrollmentDate
                    // Include other properties as needed
                };

                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }


        public ResponseDTO GetTeacherPaginated(int page, int limit)
        {
            var response = new ResponseDTO();
            try
            {
                var data = _mapper.Map<List<GetTeacherDTO>>(_teacherRepository.GetTeacherPaginated(page, limit).ToList());
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

           public ResponseDTO GetTeacherByEmail(string email)
        {
            var response = new ResponseDTO();
            try
            {
                var user = _teacherRepository.GetTeacherByEmail(email);
                if (user == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                var data = _mapper.Map<GetTeacherDTO>(user);
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO UpdateTeacher(UpdateTeacherDTO teacher)
        {
            var response = new ResponseDTO();
            try
            {
                var teacherById = _teacherRepository.GetTeacherById(teacher.Id);
                if (teacherById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Teacher not found";
                    return response;
                }

                teacherById.Name = teacher.Name;
                teacherById.Email = teacher.Email;

                var updateFlag = _teacherRepository.UpdateTeacher(teacherById);
                if (updateFlag)
                {
                    response.Status = 200;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update teacher";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }


        public ResponseDTO AddAttendance(AddAttendanceDTO attendance)
        {
            var response = new ResponseDTO();

            try
            {
                var attendanceModel = new Attendance
                {
                    TeacherId = attendance.TeacherId,
                    StudentId = attendance.StudentId,
                    Name = attendance.Name,
                    Class = attendance.Class,
                    Subject = attendance.Subject,
                    IsPresent = attendance.IsPresent,
                    Date = attendance.Date,
                    IsActive = true
                };

                var attendanceId = _attendanceRepository.AddAttendance(attendanceModel);

                if (attendanceId == 0)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add attendance";
                    return response;
                }

                response.Status = 201;
                response.Message = "Created";
                response.Data = attendanceId;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }

            return response;
        }



        public ResponseDTO GetAttendance()
        {
            var response = new ResponseDTO();

            try
            {
                var attendance = _attendanceRepository.GetAttendance();

                response.Status = 200;
                response.Message = "Success";
                response.Data = attendance;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO UpdateAttendance(UpdateAttendanceDTO attendanceDTO)
        {
            var response = new ResponseDTO();
            try
            {
                var attendance = _attendanceRepository.GetAttendanceByStudentId(attendanceDTO.Id);
                if (attendance == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Attendance not found";
                    return response;
                }

                attendance.Name = attendanceDTO.Name;
                attendance.Date = attendanceDTO.Date;
                attendance.Subject = attendanceDTO.Subject;
                attendance.IsPresent = attendanceDTO.IsPresent;

                var updateFlag = _attendanceRepository.UpdateAttendance(attendance);
                if (updateFlag)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update attendance";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO AddGradebook(AddGradebookDTO gradebook)
        {
            var response = new ResponseDTO();

            try
            {
                var gradebookModel = new Gradebook
                {
                    StudentName = gradebook.StudentName,
                    Subject = gradebook.Subject,
                    Marks = gradebook.Marks,
                    TotalMarks = gradebook.TotalMarks,
                    Date = gradebook.Date
                };

                var gradebookId = _gradebookRepository.AddGradebook(gradebookModel);

                if (gradebookId == 0)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add gradebook record";
                    return response;
                }

                response.Status = 201;
                response.Message = "Created";
                response.Data = gradebookId;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }

            return response;
        }


        public ResponseDTO GetGradebook()
        {
            var response = new ResponseDTO();

            try
            {
                var gradebook = _gradebookRepository.GetGradebook();

                response.Status = 200;
                response.Message = "Success";
                response.Data = gradebook;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }



        public ResponseDTO UpdateGradebook(UpdateGradebookDTO gradebookDTO)
        {
            var response = new ResponseDTO();

            try
            {
                var gradebook = _gradebookRepository.GetGradebookById(gradebookDTO.Id);

                if (gradebook == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Gradebook record not found";
                    return response;
                }

                gradebook.Marks = gradebookDTO.Marks;
                gradebook.TotalMarks = gradebookDTO.TotalMarks;

                var updateFlag = _gradebookRepository.UpdateGradebook(gradebook);

                if (updateFlag)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update gradebook record";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }

            return response;
        }

        public ResponseDTO GetAttendanceByTeacherId(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO GetAttendanceByStudetId(int id)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
