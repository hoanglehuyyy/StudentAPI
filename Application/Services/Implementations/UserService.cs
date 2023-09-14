using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Dtos.UserDtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUser _userRepo;
        private readonly IMapper _mapper;
        private string secretKey;
        public UserService(IUser userRepo, IMapper mapper, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        public async Task<bool> IsUserUnique(string userName)
        {
            if (await _userRepo.GetAsync(u => u.UserName == userName) == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _userRepo.GetAsync(u => u.UserName == loginRequestDto.UserName && u.Password == loginRequestDto.Password);

            // if user was not found, return empty token
            if (user == null)
            {
                return new LoginResponseDto
                {
                    Token = "",
                    UserDto = null
                };
            }

            // if user was found, generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(3),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                Token = tokenHandler.WriteToken(token),
                UserDto = _mapper.Map<UserDto>(user)
            };
            return loginResponseDto;
        }

        public async Task<UserDto> Register(RegisterRequestDto registerRequestDto)
        {
            UserDto userDto = new()
            {
                UserName = registerRequestDto.UserName,
                Password = registerRequestDto.Password,
                Name = registerRequestDto.Name,
                Role = registerRequestDto.Role
            };
            await _userRepo.CreateAsync(_mapper.Map<User>(userDto));
            return userDto;
        }
    }
}

