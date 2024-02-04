
using MinimalAPi_Example.Middlewares.RestMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<RestMiddlewareDuration>();
app.UseMiddleware<RestMiddleware>();

app.Run(async (context) =>
{
    await context.Response.WriteAsync("");
});

app.Run();
