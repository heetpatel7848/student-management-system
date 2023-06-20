using AutoMapper;
using Student_Management_System.Models;
using Student_Management_System.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            #region Token
            CreateMap<RToken, RTokenDTO>();
            CreateMap<RTokenDTO, RToken>();
            CreateMap<RTokenDTO, RToken>();
            #endregion
        }
    }
}
