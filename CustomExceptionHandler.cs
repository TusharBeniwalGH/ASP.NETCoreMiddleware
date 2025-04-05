using Microsoft.AspNetCore.Diagnostics;

namespace ASP.NETCore
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            int status = exception switch
            {
                ArgumentException=>StatusCodes.Status400BadRequest,
                _=> StatusCodes.Status500InternalServerError
            };

            httpContext.Response.StatusCode = status;

            var problemdetails = new ProblemDetails
            {
                Status = status,
                Type = exception.GetType().Name,
                Message = Convert.ToString(exception.Message) + " " + Convert.ToString(exception.StackTrace) + " " + Convert.ToString(exception.InnerException)
            };
            await httpContext.Response.WriteAsJsonAsync(problemdetails);

            return true;
        }
    }
}
