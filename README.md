### ASP.NET Core Middleware ###

# ASP.NET Core Middleware is a software that is assembled into build app pipeline with the following features:

It can decide whether to short circuit the pipeline or move the request the next middleware configured.
Can perform work before and after the next component in the pipeline.

Request delegate are used to build the request pipeline. The request delegate handle each HTTP request.
Request delegate are configured using run,map and use extension methods.An individual request delegate can be specified using an inline anonymous method or reusable classes.

Here we have created 2 middlewares:

a) Request path middleware which intercepts the request path received and inject response accordingly.

b) Custom Exception Handler,implements the IExceptionHandler interface which is then used by built-in exception handler middleware.

### Rate- Limiting Middleware ###

Rate limiting is the way to control the amount of traffic that a web application or API receives, by limiting the number 
of requests that can be made in a given period of time.This can help to improve the performance of the site or application.

Key reason to implement rate limiting:

a) Prevent abusing.

b) Ensuring fair usage.
	
c) Protecting resources.
	
d) Enhanced security.
	
e) Cost management.

Reference : https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-9.0


