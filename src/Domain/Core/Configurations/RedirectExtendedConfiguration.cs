using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations
{
    public class RedirectExtendedConfiguration : IEntityTypeConfiguration<RedirectExtended>
    {
        public void Configure(EntityTypeBuilder<RedirectExtended> builder)
        {
            builder.HasKey(a => a.RedirectExtendedId);

            builder.Property(a => a.Url)
                .HasMaxLength(1000)
                .IsRequired(true);

            builder
                .HasOne(a => a.Shortcut)
                .WithOne(a => a.RedirectExtended);
        }
    }
}