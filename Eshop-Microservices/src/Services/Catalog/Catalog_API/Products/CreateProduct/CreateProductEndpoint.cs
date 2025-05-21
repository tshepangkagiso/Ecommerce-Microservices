namespace Catalog_API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<String> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                //map request to command using mapster.
                var command = request.Adapt<CreateProductCommand>();

                //send command to cqrs.
                var result = await sender.Send(command);

                //map command to response using mapster.
                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);
            })
             .WithName("CreateProduct")
             .Produces<CreateProductResponse>(StatusCodes.Status201Created)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Create Product")
             .WithDescription("Create Procuct");
        }
    }
}
