using Student_Management_System.Models;
using Student_Management_System.Models.Interface;
using Student_Management_System.Services.DTO;
using Student_Management_System.Services.Interafce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services.Services
{
    public class UserService 
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        //private readonly IMapper _mapper;

        #endregion

        #region Constructor 
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;            //_mapper = mapper;

        }


        #endregion

        #region Methods
        public ResponseDTO AddUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO GetUser()
        {
            throw new NotImplementedException();
        }

        public ResponseDTO GetUserById(int id)
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
