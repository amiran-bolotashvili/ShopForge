using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopForge.BuildingBlocks.Application.Pagination;
using ShopForge.BuildingBlocks.Domain;
using ShopForge.Catalog.Application.Abstractions;
using ShopForge.Catalog.Application.Categories.Queries.GetCategory;

namespace ShopForge.Catalog.Application.Categories.Queries.GetCategories;

public sealed class GetCategoriesQueryHandler(ICatalogDbContext db)
    : IRequestHandler<GetCategoriesQuery, Result<PagedResult<CategoryResponse>>>
{
    public async Task<Result<PagedResult<CategoryResponse>>> Handle(GetCategoriesQuery request, CancellationToken ct)
    {
        var query = db.Categories.AsNoTracking();

        if (!string.IsNullOrEmpty(request.Search))
        {
            query = query.Where(c => c.Name.Value.Contains(request.Search));
        }

        if (request.IsActive.HasValue)
        {
            query = query.Where(c => c.IsActive == request.IsActive);
        }

        if (request.ParentId.HasValue)
        {
            query = query.Where(c => c.ParentId == request.ParentId);
        }

        var totalCount = await query.CountAsync(ct);

        query = (request.SortBy?.ToLowerInvariant(), request.Descending) switch
        {
            ("name", true) => query.OrderByDescending(c => c.Name.Value),
            _ => query.OrderBy(c => c.Name.Value)
        };

        var items = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(c => new CategoryResponse(c.Id, c.Name.Value, c.Description))
            .ToListAsync(ct);

        return new PagedResult<CategoryResponse>(items, request.Page, request.PageSize, totalCount);
    }
}
