using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Core.Context
{
    public class ShortenerContext :DbContext
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
    }
}