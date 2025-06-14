namespace Catalog.API.Features.GetAllProducts
{
    //public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;
    public record GetProductsQuery(PaginationRequest PaginationRequest) : IQuery<GetProductsResult>;
    
    //public record GetProductsResult(IEnumerable<ProductDto> Products);
    public record GetProductsResult(PaginatedResult<ProductDto> Products);

    public class GetAllProductsHandler(IApplicationDbContext dbContext)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var totalCount = await dbContext.Products.LongCountAsync(cancellationToken);

            var products = await dbContext.Products
                .OrderBy(o => o.Name)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ProjectToType<ProductDto>() // Mapster v7+ selecteaza direct din sql campurile de care are nevoie ProductDto
                .ToListAsync(cancellationToken);
            
            return new GetProductsResult(
                new PaginatedResult<ProductDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    products));
        }
    }
}