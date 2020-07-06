using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Services
{
    public interface IShortcutAdmin
    {
        public Task<Shortcut> InsertAsync(Shortcut shortcut, string url);
        public Task DeleteAsync(Shortcut shortcut);
        public Task UpdateAsync(Shortcut shortcut);
        public Task<int> SaveChangesAsync();
    }
}