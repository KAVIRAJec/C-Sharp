using Microsoft.AspNetCore.Diagnostics;

namespace Task_10.Middleware
{
    public class ExceptionHandling
    {
        private readonly RequestDelegate reqDelegate;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        public ExceptionHandling(RequestDelegate reqDelegate, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.reqDelegate = reqDelegate;
            this.logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await reqDelegate(context);
            } catch (Exception e)
            {
                logger.LogError(e, "Unhandled exception occurred!");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new  { message = "Internal Server Error" });
            }
        }

    }
}
