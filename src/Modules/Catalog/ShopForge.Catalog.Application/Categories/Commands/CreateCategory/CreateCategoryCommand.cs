using MediatR;
using ShopForge.BuildingBlocks.Domain;
using ShopForge.Catalog.Domain.Categories;

namespace ShopForge.Catalog.Application.Categories.Commands.CreateCategory;

public sealed record CreateCategoryCommand(string Name, string Description, Guid? ParentId, bool IsActive)
    : IRequest<Result<Category>>;
