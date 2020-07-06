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

        public async Task<Shortcut> InsertAsync(Shortcut shortcut, string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            if (url.Length <= 80)
            {
                shortcut.Redirect = new Redirect
                {
                    Url = url,
                    Shortcut = shortcut,
                };
                shortcut.RedirectExtended = null;
            }
            else if (url.Length <= 1000)
            {
                shortcut.RedirectExtended = new RedirectExtended
                {
                    Url = url,
                    Shortcut = shortcut,
                };
                shortcut.Redirect = null;
            }
            else
            {
                return null;
            }

            await _shortcutRepository.InsertAsync(shortcut);

            return shortcut;
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