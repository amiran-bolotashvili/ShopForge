using ShopForge.BuildingBlocks.Domain;

namespace ShopForge.Catalog.Domain.Categories;

public sealed class Category : AggregateRoot<Guid>
{
    public CategoryName Name { get; private set; } = default!;
    public string Description { get; private set; } = string.Empty;
    public Guid? ParentId { get; private set; }
    public bool IsActive { get; private set; }

    private Category(
        CategoryName name,
        string description,
        bool isActive,
        Guid? parentId = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        ParentId = parentId;
        IsActive = isActive;
    }

    public static Category Create(
        CategoryName name,
        string description,
        bool isActive,
        Guid? parentId = null)
    {
        var category = new Category(
            name,
            description,
            isActive,
            parentId);
        return category;
    }

    public void Rename(CategoryName name) => Name = name;

    public void Activate() => IsActive = true;

    public void Deactivate() => IsActive = false;

    private Category() { }
}
