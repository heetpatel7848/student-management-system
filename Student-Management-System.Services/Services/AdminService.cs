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
    public class AdminService : IAdminService
    {
        #region Fields
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructor
        public AdminService(IAdminRepository adminRepository, IMapper mapper, IUserRepository userRepository)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }



        #endregion

        #region Methods
        public ResponseDTO AddAdmin(AddAdminDTO admin)
        {
            var response = new ResponseDTO();
            try
            {

                var userId = _adminRepository.AddAdmin(_mapper.Map<Admin>(admin));
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
                    Email = admin.Email,
                    Password = admin.Password,
                    Role = "admin",
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

        public ResponseDTO DeleteAdmin(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var adminById = _adminRepository.GetAdminById(id);
                if (adminById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                adminById.IsActive = false;
                var deleteFlag = _adminRepository.DeleteAdmin(adminById);
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

        public ResponseDTO GetAdmin()
        {
            var response = new ResponseDTO();
            try
            {
                var admins = _adminRepository.GetAdmin().ToList();
                var data = admins.Select(admin => new GetAdminDTO
                {
                    Id = admin.Id,
                    Name = admin.Name,
                    Email = admin.Email
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


        public ResponseDTO GetAdminByEmail(string email)
        {
            var response = new ResponseDTO();
            try
            {
                var user = _adminRepository.GetAdminByEmail(email);
                if (user == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                var data = _mapper.Map<GetAdminDTO>(user);
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

        public ResponseDTO GetAdminById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var user = _adminRepository.GetAdminById(id);
                if (user == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                var data = _mapper.Map<GetAdminDTO>(user);
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

        public ResponseDTO GetAdminPaginated(int page, int limit)
        {
            var response = new ResponseDTO();
            try
            {
                var data = _mapper.Map<List<GetAdminDTO>>(_adminRepository.GetAdminPaginated(page, limit).ToList());
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

        public ResponseDTO UpdateAdmin(UpdateAdminDTO admin)
        {
            var response = new ResponseDTO();
            try
            {
                var adminById = _adminRepository.GetAdminById(admin.Id);
                if (adminById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Admin not found";
                    return response;
                }

                adminById.Email = admin.Email;
                adminById.Password = admin.Password;

                var updateFlag = _adminRepository.UpdateAdmin(adminById);
                if (updateFlag)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update admin";
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
