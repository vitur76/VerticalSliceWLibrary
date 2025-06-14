using System.Net.Http.Json;
using Catalog.API.Dtos;
using FluentAssertions;
using Xunit;

namespace Catalog.API.IntegrationTests;

public class ProductEndpointsTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public ProductEndpointsTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateProduct_Then_GetAllProducts_ReturnsProduct()
    {
        // Arrange
        var newProduct = new ProductDto(Guid.Empty, "Integration Product", 123.45m);

        // Act - POST
        var postResponse = await _client.PostAsJsonAsync("/products", new { product = newProduct });
        postResponse.EnsureSuccessStatusCode();

        // Act - GET
        var getResponse = await _client.GetAsync("/products?pageIndex=0&pageSize=100");
        getResponse.EnsureSuccessStatusCode();

        var result = await getResponse.Content.ReadFromJsonAsync<GetProductsResponse>();

        // Assert
        result.Should().NotBeNull();
        result!.Products.Data.Should().Contain(p => p.Name == "Integration Product");
    }

    public record GetProductsResponse(PaginatedResult<ProductDto> Products);
    public record PaginatedResult<T>(int PageIndex, int PageSize, long TotalCount, List<T> Data);
}