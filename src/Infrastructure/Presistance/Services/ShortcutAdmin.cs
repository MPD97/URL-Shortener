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

        public Task InsertAsync(Shortcut shortcut)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(Shortcut shortcut)
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