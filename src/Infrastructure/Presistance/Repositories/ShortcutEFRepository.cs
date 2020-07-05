using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Context;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Presistance.Repositories
{
    public class ShortcutEfRepository : IShortcutRepository
    {
        private readonly ShortenerContext _shortenerContext;

        public ShortcutEfRepository(ShortenerContext shortenerContext)
        {
            _shortenerContext = shortenerContext;
        }

        public async Task<Shortcut> FindByIdAsync(long id)
        {
            return await _shortenerContext.Shortcuts
                .SingleOrDefaultAsync(a => a.ShortcutId == id);
        }

        public async Task<Shortcut> FindByAliasAsync(string alias)
        {
            return await _shortenerContext.Shortcuts
                .SingleOrDefaultAsync(a => a.Alias == alias);
        }

        public async Task<long> GetCountAsync()
        {
            return await _shortenerContext.Shortcuts
                .LongCountAsync();
        }

        public async Task<List<Shortcut>> GetAllAsync()
        {
            return await _shortenerContext.Shortcuts
                .OrderByDescending(a => a.ShortcutId)
                .ToListAsync();
        }

        public async Task<List<Shortcut>> GetAllAsync(int take, int skip)
        {
            return await _shortenerContext.Shortcuts
                .OrderByDescending(a => a.ShortcutId)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task InsertAsync(Shortcut shortcut)
        {
            await _shortenerContext.AddAsync(shortcut);
        }

        public async Task DeleteAsync(Shortcut shortcut)
        {
            _shortenerContext.Remove(shortcut);
        }

        public async Task UpdateAsync(Shortcut shortcut)
        {
            _shortenerContext.Update(shortcut);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _shortenerContext.SaveChangesAsync();
        }
    }
}