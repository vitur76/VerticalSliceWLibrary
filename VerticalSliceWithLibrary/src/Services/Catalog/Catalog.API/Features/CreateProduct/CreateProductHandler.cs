namespace Catalog.API.Features.CreateProduct
{
    public record CreateProductCommand(ProductDto Product) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Product.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }

    public class CreateProductCommandHandler(IApplicationDbContext dbContext, ILogger<CreateProductCommandHandler> logger)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling CreateProductCommand for Name={ProductName}, Price={ProductPrice}",
                command.Product.Name, command.Product.Price);

            //Business logic to create a product

            //1.create Product entity from command object
            //var product = new Product
            //{
            //    Id = Guid.NewGuid(),
            //    Name = command.Product.Name,
            //    Price = command.Product.Price
            //};
            var product = command.Product.Adapt<Product>();
            product.Id = Guid.NewGuid(); // dacă nu e setat deja în DTO

            //2.save to database
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync(cancellationToken);

            logger.LogInformation("Product created with Id={ProductId}", product.Id);


            //3.return CreateProductResult result 
            return new CreateProductResult(product.Id);
        }
    }
}