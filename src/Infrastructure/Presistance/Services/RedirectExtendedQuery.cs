using System.Threading.Tasks;
using Core.Entities;
using Presistance.Repositories;

namespace Presistance.Services
{
    public class RedirectExtendedQuery : IRedirectExtendedQuery
    {
        private readonly IRedirectExtendedRepository _redirectExtendedRepository;

        public RedirectExtendedQuery(IRedirectExtendedRepository redirectExtendedRepository)
        {
            _redirectExtendedRepository = redirectExtendedRepository;
        }

        public Task<RedirectExtended> Find(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<RedirectExtended> Find(string url)
        {
            throw new System.NotImplementedException();
        }

        public Task<RedirectExtended> FindAndInclude(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<RedirectExtended> FindAndInclude(string url)
        {
            throw new System.NotImplementedException();
        }

        public Task<long> Count()
        {
            throw new System.NotImplementedException();
        }
    }
}