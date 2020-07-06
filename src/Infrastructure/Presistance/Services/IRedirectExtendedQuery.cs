using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Services
{
    public interface IRedirectExtendedQuery
    {
        public Task<RedirectExtended> Find(long id);
        public Task<RedirectExtended> Find(string url);
        public Task<RedirectExtended> FindAndInclude(long id);
        public Task<RedirectExtended> FindAndInclude(string url);
        public Task<long> Count();
    }
}