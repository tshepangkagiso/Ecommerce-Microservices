var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddRazorPages();

//Refit and Http Configurations
builder.Services.AddRefitClient<ICatalogService>().ConfigureHttpClient(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]!);
});
builder.Services.AddRefitClient<IBasketService>().ConfigureHttpClient(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]!);
});
builder.Services.AddRefitClient<IOrderingService>().ConfigureHttpClient(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]!);
});


var app = builder.Build();
// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
/* ports: Web App(http - https)
 * local dev: 5005 - 5055 
 * docker env: 6005 - 6065
 * docker inside: 8080 - 8081
 */