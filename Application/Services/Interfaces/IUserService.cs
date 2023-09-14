using System;
using Application.Dtos.UserDtos;

namespace Application.Services.Interfaces
{
	public interface IUserService
	{
		Task<bool> IsUserUnique(string userName);
		Task<UserDto> Register(RegisterRequestDto registerRequestDto);
		Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
	}
}

