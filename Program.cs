using ASP.NETCore;
using System.Threading.RateLimiting;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpcontext =>
    RateLimitPartition.GetFixedWindowLimiter(
        partitionKey: httpcontext.User.Identity?.Name ?? httpcontext.Request.Headers.Host.ToString(),
        factory: partition => new FixedWindowRateLimiterOptions
        {
            AutoReplenishment = true,
            PermitLimit = 10,
            QueueLimit = 2,
            Window = TimeSpan.FromMinutes(1)
        }));
});
var app = builder.Build();
app.UseRequestPath();
app.Map("/map1", HandleMapTest1);
app.Map("/map2", HandleMapTest2);
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from non-map delegate");
});
static void HandleMapTest1(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test 1");
    });
}
static void HandleMapTest2(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test 2");
    });
}
app.UseExceptionHandler(options => { });
app.UseRateLimiter();
app.Run();
