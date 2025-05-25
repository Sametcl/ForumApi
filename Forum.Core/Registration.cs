using FluentValidation;
using Forum.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Forum.Core
{
    public static class Registration
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddTransient<ExceptionMiddleware>();
            services.AddValidatorsFromAssembly(assembly);
            return services;
        }
    }
}
