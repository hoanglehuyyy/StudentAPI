using System;
namespace Application.Dtos.UserDtos
{
	public class LoginResponseDto
	{
		public UserDto UserDto { get; set; }
		public string Token { get; set; }
	}
}

