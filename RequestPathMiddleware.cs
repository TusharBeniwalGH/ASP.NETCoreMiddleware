
namespace ASP.NETCore
{
    public class RequestPathMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestPathMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.HasValue && !context.Request.Path.Value.ToString().Equals("/"))
            {
                string result = "";
                if (context.Request.Path.Value.ToString().ToLower().Contains("map1"))
                {
                    result = "Map 1 Path Request Received" + Environment.NewLine;
                    await context.Response.WriteAsync(result);
                }
                else if (context.Request.Path.Value.ToString().ToLower().Contains("map2"))
                {
                    result = "Map 2 Path Request Received" + Environment.NewLine;
                    await context.Response.WriteAsync(result);
                }

                await _next(context);
            }
            else
            {
                await context.Response.WriteAsync("Request Path Not Defined");
            }

          
        }
    }

    public static class RequestPathMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestPath(this IApplicationBuilder app)
        {
            {
                return app.UseMiddleware<RequestPathMiddleware>();
            }
        }
    }
}
