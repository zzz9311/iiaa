using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace IvritSchool.Middleware
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
            catch (Exception error)
            {
                var client = await Bot.Bot.Get();
                await client.SendTextMessageAsync(322044387, error.Message);
                httpContext.Response.StatusCode = StatusCodes.Status200OK;
            }
        }
    }
}
