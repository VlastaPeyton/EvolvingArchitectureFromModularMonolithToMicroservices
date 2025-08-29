using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Common.Domain.BusinessRules;
using Microsoft.AspNetCore.Http;

namespace Common.API.ErrorHandling
{
    internal sealed class ExceptionMiddleware(RequestDelegate next)
    {
        private const string ContentType = "application/json";

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = ContentType; // FE kad primi Response zna kako da ga interpretira na osnovu ContentType header koji je najcesce "application/json" jer koristim Results.StatusCode(argument) 

            int statusCode;
            string message;

            switch (exception)
            {
                case BusinessRuleValidationException businessRuleValidationException:
                    statusCode = (int)HttpStatusCode.Conflict;
                    message = businessRuleValidationException.Message;
                    break;

                case ResourceNotFoundException resourceNotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = resourceNotFoundException.Message;
                    break;

                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    message = exception.Message;
                    break;
            }

            context.Response.StatusCode = statusCode;

            var result = JsonSerializer.Serialize(new ExceptionResponseMessage(statusCode, message));
            // I zbog ovoga ce biti ContentType u Response 'application/json'

            await context.Response.WriteAsync(result);

        }
    }

    public record ExceptionResponseMessage(int StatusCode, string Message);
}
