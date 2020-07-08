using System.Threading.Tasks;
using StackExchange.Redis;

namespace Presistance.Services.Cache
{
    public class RedisCacheServiceService : ICacheService
    {
        private readonly IConnectionMultiplexer _multiplexer;

        public RedisCacheServiceService(IConnectionMultiplexer multiplexer)
        {
            _multiplexer = multiplexer;
        }

        public async Task<string> GetCacheValueAsync(string key)
        {
            var database = _multiplexer.GetDatabase();
            return await database.StringGetAsync(key);
        }

        public async Task SetChacheValueAsync(string key, string value)
        {
            var database = _multiplexer.GetDatabase();
            await database.StringSetAsync(key, value);
        }
    }
}