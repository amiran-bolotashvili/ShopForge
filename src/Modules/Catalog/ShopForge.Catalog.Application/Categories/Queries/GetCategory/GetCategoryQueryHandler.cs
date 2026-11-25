using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopForge.BuildingBlocks.Domain;
using ShopForge.Catalog.Application.Abstractions;
using ShopForge.Catalog.Domain.Categories;

namespace ShopForge.Catalog.Application.Categories.Queries.GetCategory;

public sealed class GetCategoryQueryHandler(ICatalogDbContext db)
    : IRequestHandler<GetCategoryQuery, Result<CategoryResponse>>
{
    public async Task<Result<CategoryResponse>> Handle(
        GetCategoryQuery request, CancellationToken ct)
    {
        var category = await db.Categories
            .AsNoTracking()
            .Where(c => c.Id == request.Id)
            .Select(c => new CategoryResponse(c.Id, c.Name.Value, c.Description))
            .FirstOrDefaultAsync(ct);

        return category is null 
            ? Result.Failure<CategoryResponse>(CategoryErrors.NotFound)
            : category;
    }
}
