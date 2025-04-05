### ASP.NET Core Middleware ###

# ASP.NET Core Middleware is a software that is assembled into build app pipeline with the following features:

It can decide whether to short circuit the pipeline or move the request the next middleware configured.
Can perform work before and after the next component in the pipeline.

Request delegate are used to build the request pipeline. The request delegate handle each HTTP request.
Request delegate are configured using run,map and use extension methods.An individual request delegate can be specified using an inline anonymous method or reusable classes.

Reference : https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-9.0


