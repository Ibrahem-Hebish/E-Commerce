using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrustructure.Persistance.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasIndex(p => new { p.Name, p.CategoryId })
            .IsUnique();

        builder.Property(p => p.TotalPrice)
                .HasComputedColumnSql(
                    "CASE WHEN [HasDiscount] = 0 THEN [Price] ELSE [Price] - ([Price] * [DiscountPercentage] / 100) END",
                    stored: false
                );

        builder.Property(p => p.RowVersion)
            .IsRowVersion();

        builder.HasIndex(p => p.CreatedAt)
            .IsUnique(false);

        builder.Property(p => p.Price)
            .IsRequired();

        builder.Property(p => p.StockQuantity)
            .IsRequired();

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.Description)
           .IsRequired()
           .HasMaxLength(500);

        builder.Property(p => p.CreatedAt)
           .IsRequired();

        builder.HasQueryFilter(p => !p.IsDeleted);

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Products");
    }
}
