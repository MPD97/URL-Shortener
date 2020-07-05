using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Context;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Presistance.Repositories
{
    public class RedirectEfRepsitory :IRedirectRepsitory
    {
        private readonly ShortenerContext _shortenerContext;

        public RedirectEfRepsitory(ShortenerContext shortenerContext)
        {
            _shortenerContext = shortenerContext;
        }

        public async Task<Redirect> FindByIdAsync(long id)
        {
            return await _shortenerContext.Redirects.SingleOrDefaultAsync(a => a.RedirectId == id);
        }

        public async Task<Redirect> FindByUrlAsync(string url)
        {
            return await _shortenerContext.Redirects.SingleOrDefaultAsync(a => a.Url == url);
        }

        public async Task<long> GetCountAsync()
        {
            return await _shortenerContext.Redirects.CountAsync();
        }

        public async Task<List<Redirect>> GetAllAsync()
        {
            return await _shortenerContext.Redirects.ToListAsync();
        }

        public Task<List<Redirect>> GetAllAsync(int take, int skip)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertAsync(Redirect redirect)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(Redirect redirect)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Redirect redirect)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}