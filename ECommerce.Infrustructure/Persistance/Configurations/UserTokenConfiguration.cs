using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrustructure.Persistance.Configurations;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.HasKey(ut => ut.Id);

        builder.Property(ut => ut.AccessToken)
            .IsRequired();

        builder.Property(ut => ut.AccessTokenExpireDate)
           .IsRequired();

        builder.Property(ut => ut.RefreshToken)
           .IsRequired();

        builder.Property(ut => ut.RefreshTokenExpireDate)
           .IsRequired();
        
        builder.HasOne(ut => ut.User)
            .WithMany(u => u.UserTokens)
            .HasForeignKey(ut => ut.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("UserTokens");
    }
}