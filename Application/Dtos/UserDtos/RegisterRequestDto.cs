using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos.UserDtos
{
	public class RegisterRequestDto
	{
        [MaxLength(30)]
        [Required]
        public string UserName { get; set; }
        [MinLength(6)]
        [Required]
        public string Password { get; set; }
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
    }
}

