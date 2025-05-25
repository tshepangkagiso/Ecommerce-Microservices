namespace Ordering_API;

public static class DependecyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {

        return app;
    }
}
