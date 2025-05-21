using Forum.Service.Services.Abstraction;
using Forum.Service.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Forum.Service
{
    public static class Registration
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddScoped<ICategoryService ,CategoryService>();
            services.AddScoped<IPostService ,PostService>();
            services.AddScoped<ICommentService ,CommentService>();
            return services;
        }
    }
}
