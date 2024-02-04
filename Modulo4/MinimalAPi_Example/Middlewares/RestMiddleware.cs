﻿using System.Diagnostics;

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

public class RestMiddlewareDuration
{
    private readonly RequestDelegate _next;
    public RestMiddlewareDuration(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.ContentType = "text/html; charset=utf-8";

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        await _next(context);

        stopwatch.Stop();
        var duration = stopwatch.ElapsedMilliseconds;
        await context.Response.WriteAsync($"<p>Duração da Requisição em milisegundos: {duration} ms</p>");

    }
}

public class RestMiddlewareMicrosegundos
{
    private readonly RequestDelegate _next;
    public RestMiddlewareMicrosegundos(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        await _next(context);

        stopwatch.Stop();
        long durationInMicroseconds = stopwatch.ElapsedTicks * 1000000 / Stopwatch.Frequency;

        await context.Response.WriteAsync($"<p>Duração da requisição em microsegundos: {durationInMicroseconds} µs</p>");
    }

}