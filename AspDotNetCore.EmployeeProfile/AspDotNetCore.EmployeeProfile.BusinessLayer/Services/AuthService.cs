using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AspDotNetCore.EmployeeProfile.BusinessLayer.Services.IServices;
using AspDotNetCore.EmployeeProfile.BusinessLayer.Utilities;
using AspDotNetCore.EmployeeProfile.BusinessLayer.Utilities.CustomException;
using AspDotNetCore.EmployeeProfile.DAL.Repositories.IRepositories;
using AspDotNetCore.EmployeeProfile.DTO.DTO;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AspDotNetCore.EmployeeProfile.BusinessLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<UserToReturnDTO> LoginAsync(UserLoginDTO userLoginDTO)
        {
            var user = await _userRepository.GetUserAsync(u=> u.UserName == userLoginDTO.UserName.ToLower() && u.Password== userLoginDTO.Password);

            if (user == null)
            {
                throw new UserNotFoundException();
            }
            
            var userToReturn= _mapper.Map<UserToReturnDTO>(user);
            userToReturn.AccessToken =GenerateJwtToken(user.UserId,user.UserName, user.Roles);
            return userToReturn;
        }

        

        public string GenerateJwtToken(int userId, string userName, string userRoles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , userId.ToString()),
                new Claim(ClaimTypes.Name, userName.ToString()),
                new Claim(ClaimTypes.Role,userRoles)
            };
            
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:AccessTokenSecret"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(_configuration["JwtSettings:Issuer"],
                _configuration["JwtSettings:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credential);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
