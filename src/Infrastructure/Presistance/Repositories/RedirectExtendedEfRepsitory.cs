using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Context;
using Core.Entities;

namespace Presistance.Repositories
{
    public class RedirectExtendedEfRepsitory :IRedirectExtendedRepsitory
    {
        private readonly ShortenerContext _shortenerContext;

        public RedirectExtendedEfRepsitory(ShortenerContext shortenerContext)
        {
            _shortenerContext = shortenerContext;
        }

        public Task<RedirectExtended> FindByIdAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<RedirectExtended> FindByUrlAsync(string url)
        {
            throw new System.NotImplementedException();
        }

        public Task<long> GetCountAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<RedirectExtended>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<RedirectExtended>> GetAllAsync(int take, int skip)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertAsync(RedirectExtended redirectExtended)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(RedirectExtended redirectExtended)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(RedirectExtended redirectExtended)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}