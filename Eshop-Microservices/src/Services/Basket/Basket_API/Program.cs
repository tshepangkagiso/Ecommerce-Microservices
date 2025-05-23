var builder = WebApplication.CreateBuilder(args);
// Adding Services.

builder.Services.AddMarten(opts => //Data Services
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();
// Adding Pipelines.
app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();


/* ports: Basket_API (http - https)
 * local dev: 5001 - 5051 
 * docker env: 6001 - 6061
 * docker inside: 8080 - 8081
 */
