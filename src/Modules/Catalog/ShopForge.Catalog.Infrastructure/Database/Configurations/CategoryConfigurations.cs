using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopForge.Catalog.Domain.Categories;

namespace ShopForge.Catalog.Infrastructure.Database.Configurations;

internal sealed class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.Name)
            .HasConversion(
                name => name.ToString(),
                value => CategoryName.Create(value).Value)
            .HasMaxLength(CategoryName.MaxLength)
            .IsRequired();

        builder.Property(c => c.IsActive)
            .IsRequired();

        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(c => new {c.ParentId, c.Name })
            .IsUnique();
    }
}
