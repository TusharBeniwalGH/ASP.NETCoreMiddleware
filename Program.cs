using ASP.NETCore;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddProblemDetails();
var app = builder.Build();
app.UseRequestCulture();
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
app.Run();
