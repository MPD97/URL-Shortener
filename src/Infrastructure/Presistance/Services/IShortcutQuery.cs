using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Services
{
    public interface IShortcutQuery
    {
        public Task<Shortcut> Find(long id);
        public Task<Shortcut> Find(string alias);
        public Task<Shortcut> FindAndInclude(long id);
        public Task<Shortcut> FindAndInclude(string alias);
        public Task<Shortcut> Count();
    }
}