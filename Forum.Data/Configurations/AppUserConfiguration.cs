using Forum.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            var user1 = new AppUser
            {
                Id = Guid.Parse("956073A7-DC08-4F32-A7B9-CCDCE660D523"),
                UserName = "superadmin@gmail.com",
                NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                Email = "superadmin@gmail.com",
                NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                PhoneNumber = "+05439999999",
                FirstName = "Samet",
                LastName = "Cil",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            user1.PasswordHash = CreatePasswordHash(user1, "123456");

            var user2 = new AppUser
            {
                Id = Guid.Parse("734B1748-E3E6-4BD9-8024-60E44D3DB7D9"),
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "+05439999988",
                FirstName = "Admin",
                LastName = "User",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            user2.PasswordHash = CreatePasswordHash(user2, "123456");
            builder.HasData(user1, user2);
        }
        private string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
