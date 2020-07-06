using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Services
{
    public interface IRedirectExtendedQuery
    {
        public Task<RedirectExtended> Find(long id, bool include = false);
        public Task<RedirectExtended> Find(string url, bool include = false);
        public Task<long> Count();
    }
}