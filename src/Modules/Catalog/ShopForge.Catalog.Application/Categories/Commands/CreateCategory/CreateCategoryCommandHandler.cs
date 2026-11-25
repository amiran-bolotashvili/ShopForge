using MediatR;
using ShopForge.BuildingBlocks.Domain;
using ShopForge.Catalog.Application.Abstractions;
using ShopForge.Catalog.Domain.Categories;

namespace ShopForge.Catalog.Application.Categories.Commands.CreateCategory;

public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Category>>
{
    private readonly ICatalogDbContext _dbContext;

    public CreateCategoryCommandHandler(ICatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(
            CategoryName.Create(request.Name).Value,
            request.Description,
            request.IsActive,
            request.ParentId);

        await _dbContext.Categories.AddAsync(category, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result<Category>.Success(category);
    }
}
