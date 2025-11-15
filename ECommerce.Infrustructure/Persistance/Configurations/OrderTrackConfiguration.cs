using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrustructure.Persistance.Configurations;

public class OrderTrackConfiguration : IEntityTypeConfiguration<OrderTrack>
{
    public void Configure(EntityTypeBuilder<OrderTrack> builder)
    {
        builder.HasKey(ot => ot.Id);

        builder.Property(ot => ot.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(ot => ot.CreatedAt)
            .IsRequired();

        builder.ToTable("OrderTracks");

    }
}
