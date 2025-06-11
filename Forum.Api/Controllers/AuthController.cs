using Forum.Core.DTOs.Auth;
using Forum.Service.Services.Abstraction;
using Forum.Service.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await authService.LoginAsync(dto);
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpPost]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken)
        {
            var token = await authService.RefreshTokenAsync(refreshToken);
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            await authService.RegisterAsync(registerDto);
            return Ok("Kayit basarili");
        }
    }
}
