using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Services
{
    public interface IRedirectQuery
    {
        public Task<Redirect> Find(long id, bool include = false);
        public Task<Redirect> Find(string url, bool include = false);
        public Task<long> Count();
    }
}