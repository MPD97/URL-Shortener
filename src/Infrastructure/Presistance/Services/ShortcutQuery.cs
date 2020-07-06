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

        public Task<Shortcut> Find(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Shortcut> Find(string alias)
        {
            throw new System.NotImplementedException();
        }

        public Task<Shortcut> FindAndInclude(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Shortcut> FindAndInclude(string alias)
        {
            throw new System.NotImplementedException();
        }

        public Task<Shortcut> Count()
        {
            throw new System.NotImplementedException();
        }
    }
}