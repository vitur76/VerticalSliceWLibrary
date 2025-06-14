namespace Catalog.API.Features.GetAllProducts
{
    //public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);
    public record GetProductsRequest(PaginationRequest PaginationRequest);

    //public record GetProductsResponse(IEnumerable<Product> Products);
    //public record GetProductsResponse(IEnumerable<ProductDto> Products);
    public record GetProductsResponse(PaginatedResult<ProductDto> Products);

    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (
                    [AsParameters] PaginationRequest request,
                    ISender sender,
                    ILogger<Program> logger) =>
                {
                    logger.LogInformation("Received GetProducts request: {@Request}", request);

                    var result = await sender.Send(new GetProductsQuery(request));

                    var response = result.Adapt<GetProductsResponse>();

                    logger.LogInformation("Returning {Count} products", response.Products?.Data?.Count() ?? 0);

                    return Results.Ok(response);
                })
                .WithName("GetProducts")
                .Produces<GetProductsResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Products")
                .WithDescription("Get Products");
        }
    }
}