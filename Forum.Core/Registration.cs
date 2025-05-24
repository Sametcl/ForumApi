using Forum.Core.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core
{
    public static class Registration
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<ExceptionMiddleware>();
            return services;
        }
    }
}
