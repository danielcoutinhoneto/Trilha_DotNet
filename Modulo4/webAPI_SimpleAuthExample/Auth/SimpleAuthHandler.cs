using System.Text;

namespace webAPI_SimpleAuthExample.Auth;

public class SimpleAuthHandler
{
    private readonly RequestDelegate _next;
    public SimpleAuthHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.Headers.Add("WWW-Authenticate", "Basic");
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        var authHeader = context.Request.Headers["Authorization"].ToString();
        var encodedUsernamePassword = authHeader.Substring(6);
        var decodeUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
        string username = decodeUsernamePassword.Split(":")[0];
        string password = decodeUsernamePassword.Split(":")[1];

        if(username != "admin" || password != "admin")
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalidad username or password.");
            return;
        }
        await _next(context);
    }
}
