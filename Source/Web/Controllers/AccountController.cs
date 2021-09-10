using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSBRackets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Models;
using Web.Interfaces;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Logic _logic;
        private readonly ITokenService _token;

        public AccountController(Logic logic, ITokenService token)
        {
            _logic = logic;
            _token = token;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            bool userExists = await _logic.UserExists(registerDto.Username);
            if (userExists)
            {
                return BadRequest("Username is taken");
            }

            AppUser newUser = await _logic.RegisterUser(registerDto);

            return new UserDto
            {
                Username = newUser.UserName,
                Token = _token.CreateToken(newUser)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            AppUser loginUser = await _logic.LoginUser(loginDto);

            if (loginUser == null)
            {
                return Unauthorized("Username and password combination does not exist.");
            }

            AppUser user = _logic.CheckPassword(loginUser, loginDto);

            if (user == null)
            {
                return Unauthorized("Username and password combination does not exist.");
            }

            return new UserDto
            {
                Username = user.UserName,
                Token = _token.CreateToken(user)
            };
        }
    }
}
