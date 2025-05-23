namespace BuildingBlocks.Exceptions.Handler;

/**
 * This class is a custom global exception handler implementing IExceptionHandler.
 * It maps known exception types to appropriate HTTP status codes and structures the error
 * response as a ProblemDetails object, which conforms to RFC 7807.
 * 
 * - Logs the error message and timestamp using ILogger.
 * - Supports mapping for:
 *   - InternalServerException → 500 Internal Server Error
 *   - ValidationException → 400 Bad Request (includes validation errors)
 *   - BadRequestException → 400 Bad Request
 *   - NotFoundException → 404 Not Found
 *   - Default fallback → 500 Internal Server Error
 * - Returns a structured JSON response containing:
 *   - Title, Detail, StatusCode
 *   - Path of the request (`Instance`)
 *   - TraceId for correlation
 *   - Validation errors (if applicable)
 * 
 * This helps ensure consistent and informative error responses across the application.
 */
public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger): IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError("Error Message: {exceptionMessage}, Time of occurrence {time}",exception.Message, DateTime.UtcNow);

        (string Detail, string Title, int StatusCode) details = exception switch
        {
            InternalServerException =>
            (
                exception.Message,
                exception.GetType().Name,
                context.Response.StatusCode = StatusCodes.Status500InternalServerError
            ),
            ValidationException =>
            (
                exception.Message,
                exception.GetType().Name,
                context.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            BadRequestException =>
            (
                exception.Message,
                exception.GetType().Name,
                context.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            NotFoundException =>
            (
                exception.Message,
                exception.GetType().Name,
                context.Response.StatusCode = StatusCodes.Status404NotFound
            ),
            _ =>
            (
                exception.Message,
                exception.GetType().Name,
                context.Response.StatusCode = StatusCodes.Status500InternalServerError
            )
        };

        var problemDetails = new ProblemDetails
        {
            Title = details.Title,
            Detail = details.Detail,
            Status = details.StatusCode,
            Instance = context.Request.Path
        };

        problemDetails.Extensions.Add("traceId", context.TraceIdentifier);

        if (exception is ValidationException validationException)
        {
            problemDetails.Extensions.Add("ValidationErrors", validationException.Errors);
        }

        await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);
        return true;
    }
}
