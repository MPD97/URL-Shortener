using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Context;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Presistance.Repositories
{
    public class RedirectEfRepository : IRedirectRepository
    {
        private readonly ShortenerContext _shortenerContext;

        public RedirectEfRepository(ShortenerContext shortenerContext)
        {
            _shortenerContext = shortenerContext;
        }

        public async Task<Redirect> FindByIdAsync(long id, bool include = false)
        {
            IQueryable<Redirect> result = _shortenerContext.Redirects;
           
            if (include)
            {
                result = result
                    .Include(a => a.Shortcut)
                    .ThenInclude(a => a.RedirectExtended);
            }

            return await result.SingleOrDefaultAsync(a => a.RedirectId == id);
        }

        public async Task<Redirect> FindByUrlAsync(string url, bool include = false)
        {
            IQueryable<Redirect> result = _shortenerContext.Redirects;
           
            if (include)
            {
                result = result
                    .Include(a => a.Shortcut)
                    .ThenInclude(a => a.RedirectExtended);
            }

            return await result.SingleOrDefaultAsync(a => a.Url == url);
        }

        public async Task<long> GetCountAsync()
        {
            return await _shortenerContext.Redirects
                .CountAsync();
        }

        public async Task<List<Redirect>> GetAllAsync()
        {
            return await _shortenerContext.Redirects
                .OrderByDescending(a => a.RedirectId)
                .ToListAsync();
        }

        public async Task<List<Redirect>> GetAllAsync(int take, int skip)
        {
            return await _shortenerContext.Redirects
                .OrderByDescending(a => a.RedirectId)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task InsertAsync(Redirect redirect)
        {
            await _shortenerContext.Redirects
                .AddAsync(redirect);
        }

        public async Task DeleteAsync(Redirect redirect)
        {
             _shortenerContext.Redirects
                 .Remove(redirect);
        }

        public async Task UpdateAsync(Redirect redirect)
        {
            _shortenerContext.Redirects
                .Update(redirect);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _shortenerContext
                .SaveChangesAsync();
        }
    }
}