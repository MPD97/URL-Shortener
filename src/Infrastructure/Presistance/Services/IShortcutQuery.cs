using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Services
{
    public interface IShortcutQuery
    {
        public Task<Shortcut> Find(long id, bool include = false);
        public Task<Shortcut> Find(string alias, bool include = false);
        public Task<List<Shortcut>> All();
        public Task<List<Shortcut>> All(int take, int skip);
        public Task<long> Count();
    }
}