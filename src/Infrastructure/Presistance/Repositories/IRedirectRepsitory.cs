using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Repositories
{
    public interface IRedirectRepsitory
    {
        public Task<Redirect> FindByIdAsync(long id);
        public Task<Redirect> FindByUrlAsync(string url);
        public Task<long> GetCountAsync();
        public Task<List<Redirect>> GetAllAsync();
        public Task<List<Redirect>> GetAllAsync(int take, int skip);
        public Task InsertAsync(Redirect redirect);
        public Task DeleteAsync(Redirect redirect);
        public Task UpdateAsync(Redirect redirect);
        public Task<int> SaveChangesAsync();
    }
}