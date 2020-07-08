using System.Threading.Tasks;
using StackExchange.Redis;

namespace Presistance.Services.Cache
{
    public class RedisCache : ICache
    {
        private readonly IConnectionMultiplexer _multiplexer;

        public RedisCache(IConnectionMultiplexer multiplexer)
        {
            _multiplexer = multiplexer;
        }

        public Task<string> GetCacheValueAsync(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task SetChacheValueAsync(string key, string value)
        {
            throw new System.NotImplementedException();
        }
    }
}