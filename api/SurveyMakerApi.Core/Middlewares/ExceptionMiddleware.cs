using Microsoft.AspNetCore.Http;
using SurveyMakerApi.Core.Controllers;
using SurveyMakerApi.Core.Exceptions;
using System.Net;

namespace SurveyMakerApi.Core.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            switch (exception)
            {
                case NotFoundException e:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case AlreadyExistsException e:
                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;
                case UnAuthorizedException e:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case ForbiddenException e:
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    break;
                case BadRequestException e:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            return context.Response.WriteAsync(new ErrorResponse()
            {
                Status = context.Response.StatusCode,
                Message = exception.Message,
                Exception = exception.GetType().Name
            }
            .ToString());
        }
    }
}
