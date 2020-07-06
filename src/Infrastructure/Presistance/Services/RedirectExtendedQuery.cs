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

        public async Task<RedirectExtended> Find(long id, bool include = false)
        {
            return await _redirectExtendedRepository.FindByIdAsync(id,include);
        }

        public async Task<RedirectExtended> Find(string url, bool include = false)
        {
            return await _redirectExtendedRepository.FindByUrlAsync(url,include);
        }

        public async Task<long> Count()
        {
            return await _redirectExtendedRepository.GetCountAsync();
        }
    }
}