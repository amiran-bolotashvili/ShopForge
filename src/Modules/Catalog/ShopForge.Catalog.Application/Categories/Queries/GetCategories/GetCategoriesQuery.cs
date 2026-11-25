using MediatR;
using ShopForge.BuildingBlocks.Application.Pagination;
using ShopForge.BuildingBlocks.Domain;
using ShopForge.Catalog.Application.Categories.Queries.GetCategory;

namespace ShopForge.Catalog.Application.Categories.Queries.GetCategories;

public sealed record GetCategoriesQuery(
    string? Search, 
    bool? IsActive,
    Guid? ParentId,
    string? SortBy,
    bool Descending,
    int Page = 1,
    int PageSize = 20) : IRequest<Result<PagedResult<CategoryResponse>>>;
