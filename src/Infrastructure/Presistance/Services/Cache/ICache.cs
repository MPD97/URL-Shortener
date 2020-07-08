using System.Threading.Tasks;

namespace Presistance.Services.Cache
{
    public interface ICache
    {
        public Task<string> GetCacheValueAsync(string key);
        public Task SetChacheValueAsync(string key, string value);
    }
}