using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApi.Business.Middlewares
{
    public class BookMiddleware
    {
        private readonly RequestDelegate _next;
        public BookMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("Welcome!\n");
            await _next.Invoke(context);
            await context.Response.WriteAsync("Bye!\n");
        }
    }
    static public class BookMiddlewareEntension
    {
        public static IApplicationBuilder UseBook(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BookMiddleware>();
        }
    }
}