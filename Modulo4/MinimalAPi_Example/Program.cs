
using MinimalAPi_Example.Middlewares.RestMiddleware;
using MinimalAPi_Example.Middlewares.RestMiddlewareException;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<RestMiddlewareException>("/Error");
app.UseStatusCodePagesWithRedirects("/Error/{0}");
app.UseMiddleware<RestMiddlewareMicrosegundos>();
app.UseMiddleware<RestMiddlewareDuration>();
app.UseMiddleware<RestMiddleware>();

app.Run(async (context) =>
{
    await context.Response.WriteAsync("");
});

app.Run();

