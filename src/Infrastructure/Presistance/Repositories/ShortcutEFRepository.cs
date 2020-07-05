using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Repositories
{
    public class ShortcutEFRepository :IShortcutRepository
    {
        public Task<Shortcut> FindByIdAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Shortcut> FindByAliasAsync(string alias)
        {
            throw new System.NotImplementedException();
        }

        public Task<long> GetCountAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Shortcut>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task InsertAsync(Shortcut shortcut)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Shortcut shortcut)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}