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

            long redirectId = 1;
            var redirectFaker = new Faker<Redirect>()
                .RuleFor(a => a.Url, f => f.Internet.Url())
                .RuleFor(a => a.RedirectId, f => redirectId++);
            
            long redirectExtendedId = 1;
            var redirectExtendedFaker = new Faker<RedirectExtended>()
                .RuleFor(a => a.Url, f => f.Internet.Url())
                .RuleFor(a => a.RedirectExtendedId, f => redirectExtendedId++);
            
            long shortcutId = 1;
            var shortcutFakerOne = new Faker<Shortcut>()
                .RuleFor(a => a.Alias, f => f.Random.AlphaNumeric(new Random().Next(3,30)))
                .RuleFor(a => a.ShortcutId, f => shortcutId++)
                .RuleFor(a => a.TimesRedirect, f => f.Random.Long(min:0, max: 999999999));
            
            
            for (var i = 0; i < 10000; i++)
            {
                if (i % 2 == 0)
                {
                    Redirect redirect = redirectFaker.Generate();
                    Shortcut shortcut = shortcutFakerOne.Generate();
                  
                    redirect.ShortcutId = shortcut.ShortcutId;
                    shortcut.RedirectId = redirect.RedirectId;
                    
                    modelBuilder.Entity<Redirect>().HasData(redirect);
                    modelBuilder.Entity<Shortcut>().HasData(shortcut);
                }
                else
                {
                    RedirectExtended redirect = redirectExtendedFaker.Generate();
                    Shortcut shortcut = shortcutFakerOne.Generate();
                  
                    redirect.ShortcutId = shortcut.ShortcutId;
                    shortcut.RedirectExtendedId = redirect.RedirectExtendedId;
                    
                    modelBuilder.Entity<RedirectExtended>().HasData(redirect);
                    modelBuilder.Entity<Shortcut>().HasData(shortcut);
                }
            }


            base.OnModelCreating(modelBuilder);
        }
    }
}