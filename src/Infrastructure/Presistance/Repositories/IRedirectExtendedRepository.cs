
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Repositories
{
    public interface IRedirectExtendedRepository
    {
        public Task<RedirectExtended> FindByIdAsync(long id);
        public Task<RedirectExtended> FindByUrlAsync(string url);
        public Task<long> GetCountAsync();
        public Task<List<RedirectExtended>> GetAllAsync();
        public Task<List<RedirectExtended>> GetAllAsync(int take, int skip);
        public Task InsertAsync(RedirectExtended redirectExtended);
        public Task DeleteAsync(RedirectExtended redirectExtended);
        public Task UpdateAsync(RedirectExtended redirectExtended);
        public Task<int> SaveChangesAsync();
    }
}