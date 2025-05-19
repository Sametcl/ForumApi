using Forum.Service.Services.Abstraction;
using Forum.Service.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Service
{
    public static class Registration
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService ,CategoryService>();
            return services;
        }
    }
}
