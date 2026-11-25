using Microsoft.EntityFrameworkCore;
using ShopForge.Catalog.Application.Abstractions;
using ShopForge.Catalog.Domain.Categories;

namespace ShopForge.Catalog.Infrastructure.Database;

public sealed class CatalogDbContext(DbContextOptions<CatalogDbContext> options) 
    : DbContext(options), ICatalogDbContext
{
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("catalog");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
    }
}
