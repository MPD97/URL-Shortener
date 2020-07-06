using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Repositories
{
    public interface IRedirectExtendedRepository
    {
        public Task<RedirectExtended> FindByIdAsync(long id, bool include = false);
        public Task<RedirectExtended> FindByUrlAsync(string url, bool include = false);
        public Task<long> GetCountAsync();
        public Task<List<RedirectExtended>> GetAllAsync();
        public Task<List<RedirectExtended>> GetAllAsync(int take, int skip);
        public Task InsertAsync(RedirectExtended redirectExtended);
        public Task DeleteAsync(RedirectExtended redirectExtended);
        public Task UpdateAsync(RedirectExtended redirectExtended);
        public Task<int> SaveChangesAsync();
    }
}