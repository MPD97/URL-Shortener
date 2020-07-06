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

        public async Task<Shortcut> Find(long id)
        {
            return await _shortcutRepository.FindByIdAsync(id);
        }

        public async Task<Shortcut> Find(string alias)
        {
            return await _shortcutRepository.FindByAliasAsync(alias);
        }

        public async Task<Shortcut> FindAndInclude(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Shortcut> FindAndInclude(string alias)
        {
            throw new System.NotImplementedException();
        }

        public async Task<long> Count()
        {
            return await _shortcutRepository.GetCountAsync();
        }
    }
}