using System.Threading.Tasks;
using Core.Entities;
using Presistance.Repositories;

namespace Presistance.Services
{
    public class ShortcutAdmin : IShortcutAdmin
    {
        private readonly IShortcutRepository _shortcutRepository;

        public ShortcutAdmin(IShortcutRepository shortcutRepository)
        {
            _shortcutRepository = shortcutRepository;
        }

        public async Task InsertAsync(Shortcut shortcut)
        {
            await _shortcutRepository.InsertAsync(shortcut);
        }

        public async Task DeleteAsync(Shortcut shortcut)
        {
            await _shortcutRepository.DeleteAsync(shortcut);
        }

        public async Task UpdateAsync(Shortcut shortcut)
        {
            await _shortcutRepository.UpdateAsync(shortcut);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _shortcutRepository.SaveChangesAsync();
        }
    }
}