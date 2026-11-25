using MediatR;
using ShopForge.BuildingBlocks.Domain;

namespace ShopForge.Catalog.Application.Categories.Queries.GetCategory;

public sealed record GetCategoryQuery(Guid Id) : IRequest<Result<CategoryResponse>>;
