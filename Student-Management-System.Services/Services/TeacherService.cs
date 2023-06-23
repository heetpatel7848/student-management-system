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
        #endregion

        #region Constructor
        public TeacherService(ITeacherRepository teacherRepository, IAttendanceRepository attendanceRepository , IMapper mapper , IUserRepository userRepository)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _attendanceRepository = attendanceRepository;
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
                var data = _mapper.Map<List<GetTeacherDTO>>(_teacherRepository.GetTeacher().ToList());
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
                var user = _teacherRepository.GetTeacherById(id);
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
                    response.Error = "User not found";
                    return response;
                }
                var userByEmail = _teacherRepository.GetTeacherByEmail(teacher.Email);
                if (userByEmail != null && userByEmail.Id != teacher.Id)
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Email already exists";
                    return response;
                }
                var updateFlag = _teacherRepository.UpdateTeacher(_mapper.Map<Teacher>(teacher));
                if (updateFlag)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update user";
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


        #endregion
    }
}
