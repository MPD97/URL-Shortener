using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Repositories
{
    public interface IShortcutRepository
    {
        public Task<Shortcut> FindByIdAsync(long id);
        public Task<Shortcut> FindByAliasAsync(string alias, bool include = false);
        public Task<long> GetCountAsync();
        public Task<List<Shortcut>> GetAllAsync();
        public Task<List<Shortcut>> GetAllAsync(int take, int skip);
        public Task InsertAsync(Shortcut shortcut);
        public Task DeleteAsync(Shortcut shortcut);
        public Task UpdateAsync(Shortcut shortcut);
        public Task<int> SaveChangesAsync();
    }
}