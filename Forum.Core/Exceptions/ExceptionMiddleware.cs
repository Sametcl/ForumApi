using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System.Net.Http;

namespace Forum.Core.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
			try
			{
				await next(httpContext);
			}
			catch (Exception ex )
			{
			
			}
        }

		private static Task HandleExceptionAsync(HttpContext httpcontext, Exception exception)
        {
			int statusCode = GetStatusCode(exception);
			httpcontext.Response.ContentType = "application/json";
			httpcontext.Response.StatusCode=statusCode;
            //gelecek 
            return Task.CompletedTask;
        }
        private static int GetStatusCode(Exception exception) =>
          exception switch
          {
              BadRequestException => StatusCodes.Status400BadRequest,
              NotFoundException => StatusCodes.Status404NotFound,
              ValidationException => StatusCodes.Status422UnprocessableEntity,
              _ => StatusCodes.Status500InternalServerError,
          };
    }
}
