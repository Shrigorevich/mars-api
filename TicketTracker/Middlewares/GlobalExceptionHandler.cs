using CommonObjects;
using Services.Contracts;

namespace TicketTracker.Middlewares;

public class GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context); // Continue processing the request
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception occured");
            await HandleExceptionAsync(context);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        response.StatusCode = StatusCodes.Status500InternalServerError;
        var error = new ErrorObject(ApiErrorCode.ServerError, "Server error occurred");

        await response.WriteAsJsonAsync(error);
    }
}