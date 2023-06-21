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
    public class TeacherService : ITeacherService
    {
        #region Fileds
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }



        #endregion

        #region Methods
        public ResponseDTO AddTeacher(AddTeacherDTO teacher)
        {
            var response = new ResponseDTO();
            try
            {
                var userByEmail = _teacherRepository.GetTeacherByEmail(teacher.Email);
                if (userByEmail != null)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Email already exists";
                    return response;
                }
                teacher.IsActive = true;
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

        #endregion
    }
}