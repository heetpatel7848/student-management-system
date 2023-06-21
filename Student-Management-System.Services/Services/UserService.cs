using AutoMapper;
using Student_Management_System.Models;
using Student_Management_System.Models.Interface;
using Student_Management_System.Services.DTO;
using Student_Management_System.Services.Interafce;

namespace Student_Management_System.Services.Services
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor 
        public UserService(IUserRepository userRepository , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }

      

        #endregion

        #region Methods
          public ResponseDTO AddUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO UpdateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
