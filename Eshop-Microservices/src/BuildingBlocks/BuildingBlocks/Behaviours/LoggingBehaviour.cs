namespace BuildingBlocks.Behaviours;
/**
 * This class is a MediatR pipeline behavior that logs the handling of requests.
 * It provides basic start/end logs for request handling and logs a performance warning
 * if the processing time exceeds 3 seconds.
 * 
 * - Logs the request type, response type, and request data at the start.
 * - Measures the time taken to handle the request using Stopwatch.
 * - If the request takes more than 3 seconds, logs a performance warning.
 * - Logs completion of the request with type information.
 * - Useful for tracing and identifying performance bottlenecks.
 */
public class LoggingBehavior<TRequest, TResponse> (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handle request={Request} - Response={Response} - RequestData={RequestData}",
            typeof(TRequest).Name, typeof(TResponse).Name, request);

        var timer = new Stopwatch();
        timer.Start();

        var response = await next();

        timer.Stop();
        var timeTaken = timer.Elapsed;
        if (timeTaken.Seconds > 3) // if the request is greater than 3 seconds, then log the warnings
            logger.LogWarning("[PERFORMANCE] The request {Request} took {TimeTaken} seconds.",
                typeof(TRequest).Name, timeTaken.Seconds);

        logger.LogInformation("[END] Handled {Request} with {Response}", typeof(TRequest).Name, typeof(TResponse).Name);
        return response;
    }
}
