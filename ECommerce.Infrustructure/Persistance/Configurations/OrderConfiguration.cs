using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrustructure.Persistance.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Ignore(o => o.DomainEvents);

        builder.Property(o => o.OrderDate)
            .IsRequired();

        builder.Property(o => o.TotalAmount)
            .IsRequired();

        builder.Property(o => o.Status)
            .IsRequired();

        builder.Property(o => o.Status)
            .HasConversion<int>();

        builder.HasMany(o => o.OrderTracks)
            .WithOne(ot => ot.Order)
            .HasForeignKey(ot => ot.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Orders");
    }
}
