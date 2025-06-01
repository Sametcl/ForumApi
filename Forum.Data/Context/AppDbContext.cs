using Forum.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace Forum.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var assembly = Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(assembly);
        }

    }
}
