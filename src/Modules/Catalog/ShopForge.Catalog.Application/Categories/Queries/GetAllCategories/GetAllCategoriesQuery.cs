using MediatR;
using ShopForge.BuildingBlocks.Domain;

namespace ShopForge.Catalog.Application.Categories.Queries.GetAllCategories;

public sealed record GetAllCategoriesQuery : IRequest<Result<List<CategoryListItem>>>;
