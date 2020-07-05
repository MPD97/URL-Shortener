using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Context;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Presistance.Repositories
{
    public class ShortcutEFRepository :IShortcutRepository
    {
        private readonly ShortenerContext _shortenerContext;

        public ShortcutEFRepository(ShortenerContext shortenerContext)
        {
            _shortenerContext = shortenerContext;
        }

        public async Task<Shortcut> FindByIdAsync(long id)
        {
            return await _shortenerContext.Shortcuts.SingleOrDefaultAsync(a => a.ShortcutId == id);
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