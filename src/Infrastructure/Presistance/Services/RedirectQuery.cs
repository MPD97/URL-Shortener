using System.Threading.Tasks;
using Core.Entities;
using Presistance.Repositories;

namespace Presistance.Services
{
    public class RedirectQuery : IRedirectQuery
    {
        private readonly IRedirectRepository _redirectRepository;

        public RedirectQuery(IRedirectRepository redirectRepository)
        {
            _redirectRepository = redirectRepository;
        }

        public async Task<Redirect> Find(long id, bool include = false)
        {
            return await _redirectRepository.FindByIdAsync(id, include);
        }

        public async Task<Redirect> Find(string url, bool include = false)
        {
            return await _redirectRepository.FindByUrlAsync(url, include);
        }

        public async Task<long> Count()
        {
            return await _redirectRepository.GetCountAsync();
        }
    }
}