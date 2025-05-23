var builder = WebApplication.CreateBuilder(args);
// Adding Services.


var app = builder.Build();
// Adding Pipelines.


app.Run();


/* ports: Basket_API (http - https)
 * local dev: 5001 - 5051 
 * docker env: 6001 - 6061
 * docker inside: 8080 - 8081
 */
