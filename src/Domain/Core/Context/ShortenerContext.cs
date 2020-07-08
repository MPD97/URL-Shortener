using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Bogus;
using Core.Configurations;

namespace Core.Context
{
    public class ShortenerContext : DbContext
    {
        public DbSet<Redirect> Redirects { get; set; }
        public DbSet<RedirectExtended> RedirectExtendeds { get; set; }
        public DbSet<Shortcut> Shortcuts { get; set; }

        public ShortenerContext()
        {
        }

        public ShortenerContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShortcutConfiguration());
            modelBuilder.ApplyConfiguration(new RedirectConfiguration());
            modelBuilder.ApplyConfiguration(new RedirectExtendedConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}