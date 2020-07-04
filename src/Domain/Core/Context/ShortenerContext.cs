using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Context
{
    public class ShortenerContext :DbContext
    {
        public DbSet<Redirect> Redirects { get; set; }    
        public ShortenerContext()
        {
            
        }

        public ShortenerContext(DbContextOptions options) : base(options)
        {
        }
    }
}