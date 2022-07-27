using e_gradebookAPI.Middleware.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(BadRequestException badRequest)
            {
                await context.Response.WriteAsync(badRequest.Message);
            }
            catch(NotFoundException notFound)
            {
                await context.Response.WriteAsync(notFound.Message);
            }
            catch(Exception)
            {
                await context.Response.WriteAsync("Something went wrong...");
            }
        }
    }
}
