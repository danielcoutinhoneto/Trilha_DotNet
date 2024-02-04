namespace MinimalAPi_Example.Middlewares.RestMiddleware;

public class RestMiddleware
{
    private readonly RequestDelegate _next;
    public RestMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.ContentType = "text/html; charset=utf-8";

        await context.Response.WriteAsync($"Info Custom Middleware: {DateTime.Now} - IP: {context.Connection.RemoteIpAddress}\n");

        await _next(context);
    }
}
