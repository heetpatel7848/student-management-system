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
    public class RTokenService : IRTokenService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IRTokenRepository _rTokenRepository;
        #endregion

        #region Constructor
        public RTokenService(IMapper mapper, IRTokenRepository rTokenRepository)
        {
            _mapper = mapper;
            _rTokenRepository = rTokenRepository;
        }


        #endregion

        #region Methods
        public string GetRoleName(int userId)
        {
            return _rTokenRepository.GetRoleName(userId);
        }

        public GetRTokenDTO IsUserExist(LoginDTO user)
        {
            var result = _rTokenRepository.GetUserByEmail(user.Email);
            if(result == null || result.Password != user.Password || result.Role != user.Role)
            {
                return null;
            }
            return _mapper.Map<GetRTokenDTO>(result);
        }
        #endregion
    }
}
