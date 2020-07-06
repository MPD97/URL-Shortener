using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Services
{
    public interface IShortcutAdmin
    {
        public Task InsertAsync(Shortcut shortcut);
        public Task DeleteAsync(Shortcut shortcut);
        public Task UpdateAsync(Shortcut shortcut);
        public Task<int> SaveChangesAsync();
    }
}