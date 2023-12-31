﻿using AutoMapper;
using Student_Management_System.Models;
using Student_Management_System.Models.Interface;
using Student_Management_System.Services.DTO;
using Student_Management_System.Services.DTO.AddDTO;
using Student_Management_System.Services.DTO.GetDTO;
using Student_Management_System.Services.DTO.UpdateDTO;
using Student_Management_System.Services.Interafce;

namespace Student_Management_System.Services.Services
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructor
        public StudentService(IStudentRepository studentRepository, IMapper mapper, IUserRepository userRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        #endregion


        #region Methods

        public ResponseDTO AddStudent(AddStudentDTO student)
        {
            var response = new ResponseDTO();
            try
            {             

                var userId = _studentRepository.AddStudent(_mapper.Map<Student>(student));
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
                    Email = student.Email,
                    Password = student.Password,
                    Role = "student",
                    IsActive = true
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

        public ResponseDTO DeleteStudent(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var studentById = _studentRepository.GetStudentById(id);
                if (studentById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                studentById.IsActive = false;
                var deleteFlag = _studentRepository.DeleteStudent(studentById);
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

        public ResponseDTO GetStudent()
        {
            var response = new ResponseDTO();
            try
            {
                var students = _studentRepository.GetStudent().ToList();
                var data = students.Select(student => new GetStudentDTO
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    Class = student.Class,
                    RollNo = student.RollNo
                    // Include other properties as needed
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


        public ResponseDTO GetStudentByEmail(string email)
        {
            var response = new ResponseDTO();
            try
            {
                var user = _studentRepository.GetStudentByEmail(email);
                if (user == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                var data = _mapper.Map<GetStudentDTO>(user);
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

        public ResponseDTO GetStudentById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var user = _studentRepository.GetStudentById(id);
                if (user == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                var data = _mapper.Map<GetStudentDTO>(user);
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

        public ResponseDTO GetStudentPaginated(int page, int limit)
        {
            var response = new ResponseDTO();
            try
            {
                var data = _mapper.Map<List<GetStudentDTO>>(_studentRepository.GetStudentPaginated(page, limit).ToList());
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


        public ResponseDTO UpdateStudent(UpdateStudentDTO student)
        {
            var response = new ResponseDTO();
            try
            {
                var studentById = _studentRepository.GetStudentById(student.Id);
                if (studentById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Student not found";
                    return response;
                }

                studentById.Name = student.Name;
                studentById.Email = student.Email;
                studentById.Class = student.Class;
                studentById.RollNo = student.RollNo;

                var updateFlag = _studentRepository.UpdateStudent(studentById);
                if (updateFlag)
                {
                    response.Status = 200;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update student";
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
