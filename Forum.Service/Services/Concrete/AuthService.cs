using Forum.Core.DTOs.Auth;
using Forum.Entity.Entities;
using Forum.Service.Services.Abstraction;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> userManager;

        public AuthService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public Task<string> LoginAsync(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<string> RegisterAsync(RegisterDto registerDto)
        {
            AppUser User = new()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
            };

            IdentityResult result = await userManager.CreateAsync(User,registerDto.Password);
            if (!result.Succeeded)
            {
                return string.Join(" | ", result.Errors.Select(e => e.Description));
            }
            return "kayit silemi basarili";
        }
    }
}
