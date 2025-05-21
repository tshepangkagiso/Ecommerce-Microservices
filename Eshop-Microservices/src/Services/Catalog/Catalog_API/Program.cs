var builder = WebApplication.CreateBuilder(args); // Add services to container underneath.

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();


var app = builder.Build(); // Configure the http request pipeline underneath.
app.MapCarter();

app.Run();


/* ports: Catalog_API (http - https)
 * local dev: 5000 - 5050 
 * docker env: 6000 - 6060
 * docker inside: 8080 - 8081
 */
