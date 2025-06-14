namespace Catalog.API.Features.CreateProduct
{
    //public record CreateProductRequest(string Name, decimal Price);
    public record CreateProductRequest(ProductDto Product);
    
    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (
                    CreateProductRequest request,
                    ISender sender,
                    ILogger<Program> logger) => // sau orice alt nume relevant pentru context
                {
                    logger.LogInformation("Received CreateProductRequest: {@Request}", request);

                    var command = request.Adapt<CreateProductCommand>();

                    var result = await sender.Send(command);

                    var response = result.Adapt<CreateProductResponse>();

                    logger.LogInformation("Product created with Id={ProductId}", result.Id);

                    return Results.Created($"/products/{result.Id}", response);
                })
                .WithName("CreateProduct")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Product")
                .WithDescription("Create Product");
        }

    }
}