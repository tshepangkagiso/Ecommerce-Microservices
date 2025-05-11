var builder = WebApplication.CreateBuilder(args);
// Add services to container.


var app = builder.Build();
// Configure the http request pipeline.

app.Run();


//ports: Catalog_API (http - https)
//local dev: 5000 - 5050 
//docker env: 6000 - 6060
//docker inside: 8080 - 8081