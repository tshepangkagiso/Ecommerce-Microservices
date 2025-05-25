var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiServices();
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();

/* ports: Ordering_API (http - https)
 * local dev: 5003 - 5053 
 * docker env: 6003 - 6063
 * docker inside: 8080 - 8081
 */
