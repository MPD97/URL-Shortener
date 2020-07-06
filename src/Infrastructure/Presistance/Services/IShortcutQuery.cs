using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Services
{
    public interface IShortcutQuery
    {
        public Task<Shortcut> Find(long id, bool include = false);
        public Task<Shortcut> Find(string alias, bool include = false);
        public Task<long> Count();
    }
}