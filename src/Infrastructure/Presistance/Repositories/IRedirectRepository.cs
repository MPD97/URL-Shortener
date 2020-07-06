using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Repositories
{
    public interface IRedirectRepository
    {
        public Task<Redirect> FindByIdAsync(long id, bool include = false);
        public Task<Redirect> FindByUrlAsync(string url, bool include = false);
        public Task<long> GetCountAsync();
        public Task<List<Redirect>> GetAllAsync();
        public Task<List<Redirect>> GetAllAsync(int take, int skip);
        public Task InsertAsync(Redirect redirect);
        public Task DeleteAsync(Redirect redirect);
        public Task UpdateAsync(Redirect redirect);
        public Task<int> SaveChangesAsync();
    }
}