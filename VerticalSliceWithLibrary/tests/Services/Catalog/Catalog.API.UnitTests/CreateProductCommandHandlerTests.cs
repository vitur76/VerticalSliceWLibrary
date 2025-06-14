using Catalog.API.Data;
using Catalog.API.Dtos;
using Catalog.API.Features.CreateProduct;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Catalog.API.UnitTests
{
    public class CreateProductCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateProductAndReturnId()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // new DB for each test
                .Options;

            var dbContext = new AppDbContext(options);
            var loggerMock = new Mock<ILogger<CreateProductCommandHandler>>();

            var handler = new CreateProductCommandHandler(dbContext, loggerMock.Object);
            
            var productDto = new ProductDto(Guid.Empty, "Test Product", 99.99m);
            
            var command = new CreateProductCommand(productDto);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotEqual(Guid.Empty, result.Id);

            var createdProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == result.Id);
            Assert.NotNull(createdProduct);
            Assert.Equal("Test Product", createdProduct.Name);
            Assert.Equal(99.99m, createdProduct.Price);
        }
    }
}
