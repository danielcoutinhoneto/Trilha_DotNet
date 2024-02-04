using System.Text;
using Newtonsoft.Json;

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
            // Handle the exception and send JSON to the specified endpoint
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Log or perform any other desired actions with the exception

        // Create a JSON representation of the exception
        var errorJson = JsonConvert.SerializeObject(new { ErrorMessage = exception.Message });

        // Send the JSON to the specified endpoint
        await SendErrorToEndpointAsync(errorJson);

        // Optionally, return a custom response to the client
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(errorJson);
    }

    private async Task SendErrorToEndpointAsync(string errorJson)
    {
        // Use HttpClient to send the JSON to the specified endpoint
        using (var httpClient = new HttpClient())
        {
            var content = new StringContent(errorJson, Encoding.UTF8, "application/json");
            await httpClient.PostAsync(_errorEndpoint, content);
        }
    }
}
