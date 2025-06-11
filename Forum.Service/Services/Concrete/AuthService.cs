using Forum.Core.DTOs.Auth;
using Forum.Entity.Entities;
using Forum.Service.Services.Abstraction;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Forum.Service.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IConfiguration configuration;

        public AuthService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }
        public async Task<TokenResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, loginDto.Password))
                return null;

            var token = await CreateTokenAsync(user);
            return token;
        }

        public async Task<TokenResponseDto> RefreshTokenAsync(string refreshToken)
        {
            var user = userManager.Users.FirstOrDefault(u => u.RefreshToken == refreshToken &&
                                                          u.ResfreshTokenExpiryTime > DateTime.UtcNow);
            if (user == null)
                return null;

            var token = await CreateTokenAsync(user);
            return token;
        }

        public async Task RegisterAsync(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
            };
            IdentityResult result = await userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                // Rol yoksa oluştur
                if (!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(new AppRole { Name = "User", NormalizedName = "USER" });
                }
                await userManager.AddToRoleAsync(user, "User");
            }
            else
            {
                throw new Exception("Kullanici kayit olusturulurken bir hata olustu! ");
            }
        }

        private async Task<TokenResponseDto> CreateTokenAsync(AppUser user)
        {
            var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(configuration["Jwt:AccessTokenExpirationMinutes"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.ResfreshTokenExpiryTime = DateTime.UtcNow.AddDays(Convert.ToDouble(configuration["Jwt:RefreshTokenExpirationDays"]));
            await userManager.UpdateAsync(user);

            return new TokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpireDate = token.ValidTo
            };
        }
        //GetPrincipalFromExpiredToken yapisi kurulacak 
        // apiresponse degeri dondurelecek 
        //role ekleeme userlari rolleriyle listeleme 
        //register service kurulacak 
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
