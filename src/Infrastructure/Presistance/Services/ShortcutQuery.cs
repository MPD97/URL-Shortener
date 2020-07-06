using System.Threading.Tasks;
using Core.Entities;
using Presistance.Repositories;

namespace Presistance.Services
{
    public class ShortcutQuery : IShortcutQuery
    {
        private readonly IShortcutRepository _shortcutRepository;

        public ShortcutQuery(IShortcutRepository shortcutRepository)
        {
            _shortcutRepository = shortcutRepository;
        }

        public async Task<Shortcut> Find(long id, bool include = false)
        {
            return await _shortcutRepository.FindByIdAsync(id,include);
        }

        public async Task<Shortcut> Find(string alias, bool include = false)
        {
            return await _shortcutRepository.FindByAliasAsync(alias,include);
        }
        
        public async Task<long> Count()
        {
            return await _shortcutRepository.GetCountAsync();
        }
    }
}