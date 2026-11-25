using Microsoft.EntityFrameworkCore;
using ShopForge.Catalog.Domain.Categories;

namespace ShopForge.Catalog.Application.Abstractions;

public interface ICatalogDbContext
{
    DbSet<Category> Categories { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
