using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Repositories
{
    public interface IShortcutRepository
    {
        public Task<Shortcut> FindByIdAsync(long id);
        public Task<Shortcut> FindByAliasAsync(string alias);
        public Task<long> GetCountAsync();
        public Task<IEnumerable<Shortcut>> GetAllAsync();
        public Task InsertAsync(Shortcut shortcut);
        public Task<bool> DeleteAsync(long id);
        public Task UpdateAsync(Shortcut shortcut);
        public Task<int> SaveChangesAsync();
    }
}