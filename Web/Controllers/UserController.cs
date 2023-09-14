using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.UserDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/auth")]
    [Controller]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequestDto model)
        {
            // Check if User name is unique or not
            bool isUnique = await _userService.IsUserUnique(model.UserName);
            if (!isUnique)
            {
                return BadRequest("User name already exists");
            }

            var userDto = await _userService.Register(model);
            if (userDto == null)
            {
                return BadRequest("Error while registering");
            }
            return Ok(userDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _userService.Login(model);
            if (loginResponse.UserDto == null || String.IsNullOrEmpty(loginResponse.Token))
            {
                return BadRequest("User name or password is incorrect");
            }
            return Ok(loginResponse);
        }
    }
}

