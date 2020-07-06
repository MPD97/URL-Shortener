using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Services
{
    public interface IShortcutAdmin
    {
        public Task<Shortcut> InsertAsync(string alias, string url);
        public Task DeleteAsync(Shortcut shortcut);
        public Task<Shortcut> IncreaseRedirectCount(Shortcut shortcut);
        public Task<int> SaveChangesAsync();
    }
}