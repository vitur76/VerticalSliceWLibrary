using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Catalog.API.Models;
using System;
using System.Linq;

namespace Catalog.API.Data
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            // Verifică dacă baza de date este deja populată
            if (context.Products.Any())
            {
                return;   // Baza de date a fost deja populată
            }

            // Adaugă produse noi
            context.Products.AddRange(
    new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop A",
                    Price = 1200.50m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone A",
                    Price = 800.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet A",
                    Price = 300.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop B",
                    Price = 1250.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone B",
                    Price = 850.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet B",
                    Price = 350.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop C",
                    Price = 1300.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone C",
                    Price = 900.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet C",
                    Price = 400.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop D",
                    Price = 1350.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone D",
                    Price = 950.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet D",
                    Price = 450.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop E",
                    Price = 1400.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone E",
                    Price = 1000.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet E",
                    Price = 500.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop F",
                    Price = 1450.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone F",
                    Price = 1050.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet F",
                    Price = 550.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop G",
                    Price = 1500.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone G",
                    Price = 1100.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet G",
                    Price = 600.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop H",
                    Price = 1550.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone H",
                    Price = 1150.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet H",
                    Price = 650.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop I",
                    Price = 1600.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone I",
                    Price = 1200.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet I",
                    Price = 700.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop J",
                    Price = 1650.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone J",
                    Price = 1250.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet J",
                    Price = 750.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop K",
                    Price = 1700.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone K",
                    Price = 1300.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet K",
                    Price = 800.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop L",
                    Price = 1750.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone L",
                    Price = 1350.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet L",
                    Price = 850.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop M",
                    Price = 1800.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone M",
                    Price = 1400.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet M",
                    Price = 900.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop N",
                    Price = 1850.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone N",
                    Price = 1450.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet N",
                    Price = 950.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop O",
                    Price = 1900.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone O",
                    Price = 1500.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet O",
                    Price = 1000.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop P",
                    Price = 1950.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone P",
                    Price = 1550.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet P",
                    Price = 1050.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop Q",
                    Price = 2000.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone Q",
                    Price = 1600.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet Q",
                    Price = 1100.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop R",
                    Price = 2050.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone R",
                    Price = 1650.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet R",
                    Price = 1150.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop S",
                    Price = 2100.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone S",
                    Price = 1700.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet S",
                    Price = 1200.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop T",
                    Price = 2150.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone T",
                    Price = 1750.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet T",
                    Price = 1250.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop U",
                    Price = 2200.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone U",
                    Price = 1800.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet U",
                    Price = 1300.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop V",
                    Price = 2250.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone V",
                    Price = 1850.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet V",
                    Price = 1350.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop W",
                    Price = 2300.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone W",
                    Price = 1900.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet W",
                    Price = 1400.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop X",
                    Price = 2350.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone X",
                    Price = 1950.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet X",
                    Price = 1450.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop Y",
                    Price = 2400.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone Y",
                    Price = 2000.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet Y",
                    Price = 1500.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop Z",
                    Price = 2450.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone Z",
                    Price = 2050.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tablet Z",
                    Price = 1550.00m
                }
            );

            context.SaveChanges();
        }
    }
}