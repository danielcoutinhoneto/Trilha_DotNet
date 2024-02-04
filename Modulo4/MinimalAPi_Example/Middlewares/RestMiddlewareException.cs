namespace MinimalAPi_Example.Middlewares.RestMiddlewareException;

public class RestMiddlewareException
{
    private readonly RequestDelegate _next;
    private readonly string _errorEndpoint;

    public RestMiddlewareException(RequestDelegate next, string errorEndpoint)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _errorEndpoint = errorEndpoint ?? throw new ArgumentNullException(nameof(errorEndpoint));
    }

     public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            // Handle the exception and redirect the user to a custom error page
            await HandleExceptionAsync(context, ex);
        }
    }

    public async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Log or perform any other desired actions with the exception

        // Optionally, redirect the user to a custom error page
        context.Response.Redirect("/Error");

        // Optionally, return a custom response to the client
        context.Response.StatusCode = 500;
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync("<html><body><h1>Oops, something went wrong!</h1></body></html>");
    }
}