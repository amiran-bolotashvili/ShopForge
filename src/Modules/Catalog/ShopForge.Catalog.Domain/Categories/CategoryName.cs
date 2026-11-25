using ShopForge.BuildingBlocks.Domain;

namespace ShopForge.Catalog.Domain.Categories;

public sealed record CategoryName
{
    public const int MaxLength = 100;

    public string Value { get; } = string.Empty;

    private CategoryName(string value) => Value = value;

    public static Result<CategoryName> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<CategoryName>(CategoryErrors.NameEmpty);
        }

        value = value.Trim();

        if (value.Length > MaxLength)
        {
            return Result.Failure<CategoryName>(CategoryErrors.NameTooLong);
        }

        return new CategoryName(value);
    }

    public override string ToString() => Value;
}
