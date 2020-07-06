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

        public async Task<RedirectExtended> Find(long id)
        {
            return await _redirectExtendedRepository.FindByIdAsync(id);
        }

        public async Task<RedirectExtended> Find(string url)
        {
            return await _redirectExtendedRepository.FindByUrlAsync(url);
        }

        public async Task<RedirectExtended> FindAndInclude(long id)
        {
            return await _redirectExtendedRepository.FindByIdAsync(id, true);
        }

        public async Task<RedirectExtended> FindAndInclude(string url)
        {
            return await _redirectExtendedRepository.FindByUrlAsync(url, true);
        }

        public async Task<long> Count()
        {
            return await _redirectExtendedRepository.GetCountAsync();
        }
    }
}