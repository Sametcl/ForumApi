using FluentValidation;
using FluentValidation.AspNetCore;
using Forum.Core.Exceptions;
using Forum.Core.Validators.Category;
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

            services.AddFluentValidationAutoValidation(); 
            services.AddValidatorsFromAssemblyContaining<CategoryUpdateDtoValidator>();
            

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToList();

                    var response = new ExceptionModel
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Errors = errors
                    };

                    return new BadRequestObjectResult(response);
                };
            });


            services.AddTransient<ExceptionMiddleware>();
            return services;
        }
    }
}
