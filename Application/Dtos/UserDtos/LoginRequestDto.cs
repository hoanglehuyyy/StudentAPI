using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.UserDtos
{
	public class LoginRequestDto
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
	}
}

