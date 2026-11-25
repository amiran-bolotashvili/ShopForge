using ShopForge.BuildingBlocks.Domain;

namespace ShopForge.Catalog.Domain.Categories;

public static class CategoryErrors
{
    public static readonly Error NameEmpty = new(
        "Category.NameEmpty",
        "The category name cannot be empty."
    );

    public static readonly Error NameTooLong = new(
        "Category.NameTooLong",
        "The category name cannot exceed 100 characters."
    );

    public static readonly Error NotFound = new(
        "Category.NotFound",
        "The category was not found."
    );

    public static readonly Error NameAlreadyExists = new(
        "Category.NameAlreadyExists",
        "A category with the same name already exists."
    );
}
