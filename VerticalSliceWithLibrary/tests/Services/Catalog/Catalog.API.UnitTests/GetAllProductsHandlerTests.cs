using Catalog.API.Features.GetAllProducts;
using Catalog.API.Data;
using Microsoft.EntityFrameworkCore;
using BuildingBlocks.Pagination;

namespace Catalog.API.UnitTests
{
    public class GetAllProductsHandlerTests
    {
        private IApplicationDbContext CreateDbContextWithData()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + Guid.NewGuid())
                .Options;

            var context = new AppDbContext(options);

            context.Products.AddRange(new[]
            {
                new Catalog.API.Models.Product { Id = Guid.NewGuid(), Name = "Product A", Price = 10 },
                new Catalog.API.Models.Product { Id = Guid.NewGuid(), Name = "Product B", Price = 20 },
                new Catalog.API.Models.Product { Id = Guid.NewGuid(), Name = "Product C", Price = 30 }
            });

            context.SaveChanges();
            return context;
        }

        [Fact]
        public async Task GetAllProductsHandler_ShouldReturnPaginatedResult()
        {
            // Arrange
            var dbContext = CreateDbContextWithData();
            var handler = new GetAllProductsHandler(dbContext);
            var paginationRequest = new PaginationRequest { PageIndex = 0, PageSize = 2 };
            var query = new GetProductsQuery(paginationRequest);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Products);
            Assert.Equal(2, result.Products.Data.Count());
            Assert.Equal(3, result.Products.Count); // Total in DB
            Assert.Equal(0, result.Products.PageIndex);
            Assert.Equal(2, result.Products.PageSize);
        }
    }
}
