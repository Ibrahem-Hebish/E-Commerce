using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrustructure.Persistance.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);

        builder.Property(oi => oi.Quantity)
             .IsRequired();

        builder.Property(oi => oi.UnitPrice)
             .IsRequired();

        builder.HasOne(oi => oi.Order)
             .WithMany(o => o.OrderItems)
             .HasForeignKey(o => o.OrderId)
             .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("OrderItems");

    }
}
