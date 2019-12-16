using System;
using System.Threading.Tasks;
using ClassRegister.Infrastructure.Authorization;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ClassRegister.Application.Controllers
{
    
    public class AuthController : ApiBaseController
    {
        private readonly IAuthService _authService;
        private readonly IOptions<JwtOptions> _jwtOptions;

        public AuthController(IAuthService authService, IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions;
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userFromLoginDto)
        {
            var token = await _authService.Login(userFromLoginDto.Username, userFromLoginDto.Password);
            if (token == null) return BadRequest("Username or password is incorrect");
            return Ok(new
            {
                token = token
            });
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userFroRegisterDto)
        {

            await _authService.Register(userFroRegisterDto.Role, userFroRegisterDto.FirstName,
                userFroRegisterDto.LastName, userFroRegisterDto.Email, userFroRegisterDto.PhoneNumber,
                userFroRegisterDto.Pesel, userFroRegisterDto.PostCode, userFroRegisterDto.City,
                userFroRegisterDto.Street, userFroRegisterDto.HouseNumber, userFroRegisterDto.Password, userFroRegisterDto.StudentId);

            return StatusCode(201);
        }
    }
}