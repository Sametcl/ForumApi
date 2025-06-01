using Forum.Data.Context;
using Forum.Data.Repositories.Abstractions;
using Forum.Data.Repositories.Concretes;
using Forum.Data.UnitOfWorks;
using Forum.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Data
{
    public static class Registration
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration config) 
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork , UnitOfWork>();
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            
            return services;
        }
    }
}
