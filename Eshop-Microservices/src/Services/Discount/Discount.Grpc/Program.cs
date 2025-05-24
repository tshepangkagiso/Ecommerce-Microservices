var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DiscountContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMigration();
app.MapGrpcService<DiscountService>();
app.MapGet("/", () => "gRPC Communications");
app.Run();


/* ports: Discount Grpc (http - https)
 * local dev: 5002 - 5052 
 * docker env: 6002 - 6062
 * docker inside: 8080 - 8081
 */
