﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Student_Management_System.Services.DTO;
using Student_Management_System.Services.DTO.AddDTO;
using Student_Management_System.Services.DTO.UpdateDTO;
using Student_Management_System.Services.Interafce;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IRTokenService _rTokenService;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public AuthController(IUserService userService, IRTokenService rTokenService, IConfiguration configuration)
        {
            _userService = userService;
            _rTokenService = rTokenService;
            _configuration = configuration.GetSection("JWTConfig");
        }
        #endregion

        #region Methods
        [HttpPost("login")]
        public IActionResult Login(LoginDTO user)
        {
            // check if user exists
            var result = _rTokenService.IsUserExist(user);
            if (result == null)
            {
                return Unauthorized(new ResponseDTO
                {
                    Status = 401,
                    Message = "Unauthorized",
                    Error = "Incorrect email or password"
                });
            }

            //create and add refresh token in database
           var refreshToken = Guid.NewGuid().ToString().Replace("-", "");
            var rToken = new AddRTokenDTO
            {
                RefreshToken = refreshToken,
                IsStop = false,
                CreatedOn = DateTime.UtcNow
            };
            //if (!_rTokenService.AddRefreshToken(rToken))
            //{
            //    return Unauthorized(new ResponseDTO
            //    {
            //        Status = 401,
            //        Message = "Unauthorized",
            //        Error = "Failed to add refresh token"
            //    });
            //}

            // create access token and send response
            var response = GetJwt(result.Id, refreshToken);
            return Ok(response);
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken(RefreshDTO user)
        {
            // check if refresh token exists or expired
            //var rTokenOld = _rTokenService.GetRefreshToken(user);
            //if (rTokenOld == null)
            //{
            //    return Unauthorized(new ResponseDTO
            //    {
            //        Status = 401,
            //        Message = "Unauthorized",
            //        Error = "Refresh token not found"
            //    });
            //}
            //if (rTokenOld.IsStop == true)
            //{
            //    return Unauthorized(new ResponseDTO
            //    {
            //        Status = 401,
            //        Message = "Unauthorized",
            //        Error = "Refresh token has expired"
            //    });
            //}

            // expire old refresh token and create new refresh token
            //var updateFlag = _rTokenService.ExpireRefreshToken(new UpdateRTokenDTO
            //{
            //    Id = rTokenOld.Id,
            //    IsStop = true
            //});
            var refreshToken = Guid.NewGuid().ToString().Replace("-", "");
            var rTokenNew = new AddRTokenDTO
            {
                RefreshToken = refreshToken,
                IsStop = false,
                CreatedOn = DateTime.UtcNow,
                //UserId = rTokenOld.UserId
            };
            //var addFlag = _rTokenService.AddRefreshToken(rTokenNew);
            //if (!updateFlag || !addFlag)
            //{
            //    return Unauthorized(new ResponseDTO
            //    {
            //        Status = 401,
            //        Message = "Unauthorized",
            //        Error = "Could not refresh token"
            //    });
            //}

            // create access token and send response
            var response = GetJwt(rTokenNew.UserId, refreshToken);
            return Ok(response);
        }

        private object GetJwt(int userId, string refreshToken)
        {
            var now = DateTime.UtcNow;

            // jwt claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Iat, now.ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                new Claim("Id", Convert.ToString(userId))
                // roles
            };

            // signing key
            var symmetricKeyAsBase64 = _configuration["SecretKey"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // token options
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Issuer"],
                audience: _configuration["Aud"],
                claims: claims,
                expires: now.Add(TimeSpan.FromHours(24)),
                signingCredentials: signingCredentials
            );

            // active token
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            // create and return response
            var response = new
            {
                id = userId,
                access_token = tokenString,
                refresh_token = refreshToken,
                expires_in = (int)TimeSpan.FromHours(24).TotalSeconds
            };
            return response;
        }
        #endregion
    }
}
