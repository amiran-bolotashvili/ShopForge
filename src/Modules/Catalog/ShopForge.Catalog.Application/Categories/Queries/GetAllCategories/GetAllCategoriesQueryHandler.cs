using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopForge.BuildingBlocks.Domain;
using ShopForge.Catalog.Application.Abstractions;

namespace ShopForge.Catalog.Application.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler(ICatalogDbContext db) 
    : IRequestHandler<GetAllCategoriesQuery, Result<List<CategoryListItem>>>
{
    public async Task<Result<List<CategoryListItem>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await db.Categories
            .AsNoTracking()
            .Select(c => new CategoryListItem(c.Id, c.Name.Value))
            .ToListAsync(cancellationToken);

        return categories;
    }
}
