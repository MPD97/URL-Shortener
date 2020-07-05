using System.Collections.Generic;
using System.Linq;
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

        public async Task<Shortcut> FindByAliasAsync(string alias)
        {
            return await _shortenerContext.Shortcuts.SingleOrDefaultAsync(a => a.Alias == alias);
        }

        public async Task<long> GetCountAsync()
        {
            return await _shortenerContext.Shortcuts.LongCountAsync();
        }

        public async Task<List<Shortcut>> GetAllAsync()
        {
            return await _shortenerContext.Shortcuts.OrderByDescending(a => a.ShortcutId).ToListAsync();
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