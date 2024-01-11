using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Gudang_Super_Market.Models;

namespace Gudang_Super_Market;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(context, ex);
        }
    }

    private static async Task HandleErrorAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = 500; // Internal Server Error
        context.Response.ContentType = "application/json";

        var errorDetails = new Models.ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = "Terjadi kesalahan internal pada server.",
            ExceptionMessage = exception.Message,
            StackTrace = exception.StackTrace
            
        };

        await context.Response.WriteAsync(errorDetails.ToString());
    }
}