namespace BuildingBlocks.Behaviours;
/**
 * This class is a MediatR pipeline behavior that performs validation on incoming requests 
 * using FluentValidation. It intercepts a command before it reaches its handler, 
 * runs all configured validators for the request, and throws a ValidationException 
 * if any validation errors are found.
 * 
 * - Applies to commands implementing ICommand<TResponse> Create,Update and Delete.
 * - Executes all validators for the incoming request in parallel.
 * - Aggregates validation failures and throws if any are found.
 * - If validation passes, proceeds to the next handler in the pipeline.
 */
public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Any())
        {
            throw new ValidationException(failures);
        }
        
        return await next();
    }
}
