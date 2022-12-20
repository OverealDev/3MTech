using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication2.Middleware
{
      public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public Middleware(RequestDelegate next, ILoggerFactory logger) //public constructor
        {
            _next = next;
            _logger = logger.CreateLogger<Middleware>();
        }

        public async Task Invoke(HttpContext httpContext)
        {

            using (var reader = new StreamReader(httpContext.Request.Body))//read and log request
            {
               var requestBody = reader.ReadToEnd();
               //As this is a middleware below line will make sure it will log each and every request body
                _logger.LogInformation(requestBody);
            }
                await _next.Invoke(httpContext); //move to the next middleware
        }
    }


    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseLog(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<Middleware>();
        }
    }
}
