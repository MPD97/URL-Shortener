﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Configurations
{
    public class ShortcutConfiguration : IEntityTypeConfiguration<Shortcut>
    {
        public void Configure(EntityTypeBuilder<Shortcut> builder)
        {
            builder.HasKey(a => a.ShortcutId);

            builder.HasIndex(a => a.Alias)
                .IsUnique(true);
            
            builder.Property(a => a.Alias)
                .HasMaxLength(30)
                .IsRequired(true);

            builder
                .HasOne(a => a.Redirect)
                .WithOne(a => a.Shortcut)
                .HasForeignKey<Redirect>(a => a.ShortcutId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(a => a.RedirectExtended)
                .WithOne(a => a.Shortcut)
                .HasForeignKey<RedirectExtended>(a => a.ShortcutId)
                .OnDelete(DeleteBehavior.Cascade);;
        }
    }
}
