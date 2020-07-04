using Microsoft.EntityFrameworkCore;

namespace Core.Context
{
    public class ShortenerContext :DbContext
    {
        public ShortenerContext()
        {
            
        }

        public ShortenerContext(DbContextOptions options) : base(options)
        {
        }
    }
}