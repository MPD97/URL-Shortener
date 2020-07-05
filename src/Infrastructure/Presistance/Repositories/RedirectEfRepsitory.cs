using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Repositories
{
    public class RedirectEfRepsitory :IRedirectRepsitory
    {
        public Task<Redirect> FindByIdAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Redirect> FindByUrlAsync(string url)
        {
            throw new System.NotImplementedException();
        }

        public Task<long> GetCountAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Redirect>> GetAllAsync()
        {
            throw new System.NotImplementedException();
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