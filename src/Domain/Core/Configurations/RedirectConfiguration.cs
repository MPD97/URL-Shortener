using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations
{
    public class RedirectConfiguration : IEntityTypeConfiguration<Redirect>
    {
        public void Configure(EntityTypeBuilder<Redirect> builder)
        {
            builder.HasKey(a => a.RedirectId);

            builder.Property(a => a.Url)
                .HasMaxLength(80)
                .IsRequired(true);

            builder
                .HasOne(a => a.Shortcut)
                .WithOne(a => a.Redirect);
        }
    }
}