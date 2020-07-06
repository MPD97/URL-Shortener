using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Services
{
    public interface IRedirectQuery
    {
        public Task<Redirect> Find(long id);
        public Task<Redirect> Find(string url);
        public Task<Redirect> FindAndInclude(long id);
        public Task<Redirect> FindAndInclude(string url);
        public Task<long> Count();

    }
}