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

        public async Task<Shortcut> InsertAsync(string alias, string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            Shortcut shortcut = new Shortcut
            {
                Alias = alias
            };
            
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

        public async Task<Shortcut> IncreaseRedirectCount(Shortcut shortcut)
        {
            shortcut.TimesRedirect += 1;
            await _shortcutRepository.UpdateAsync(shortcut);

            return shortcut;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _shortcutRepository.SaveChangesAsync();
        }
    }
}