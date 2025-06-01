using Forum.Core.DTOs.Auth;
using Forum.Service.Services.Abstraction;
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
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await authService.RegisterAsync(registerDto);
            return Ok(result);
        }
    }
}
