using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System.Net.Http;
using System.Text.Json;

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
                await HandleExceptionAsync(httpContext, ex);
            }
        }

		private static Task HandleExceptionAsync(HttpContext httpcontext, Exception exception)
        {
			int statusCode = GetStatusCode(exception);
			httpcontext.Response.ContentType = "application/json";
			httpcontext.Response.StatusCode=statusCode;
            List<string> errors = new()
            {
                exception.Message,
            };
            var response = new ExceptionModel
            {
                StatusCode = statusCode,
                Errors = new[] { exception.Message }
            };

            var json = JsonSerializer.Serialize(response);
            return httpcontext.Response.WriteAsync(json);

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
