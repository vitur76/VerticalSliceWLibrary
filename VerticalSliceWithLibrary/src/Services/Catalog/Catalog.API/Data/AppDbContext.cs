namespace Catalog.API.Data
{ public class AppDbContext : DbContext, IApplicationDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<global::Catalog.API.Models.Product> Products => Set<global::Catalog.API.Models.Product>();
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Configurează seeding-ul datelor
        //    modelBuilder.Entity<global::Catalog.API.Models.Product>().HasData(
        //        new global::Catalog.API.Models.Product
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Laptop",
        //            Price = 1200.50m
        //        },
        //        new global::Catalog.API.Models.Product
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Smartphone",
        //            Price = 800.00m
        //        },
        //        new global::Catalog.API.Models.Product
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Tablet",
        //            Price = 300.00m
        //        }
        //    );
        //}
    }
}
