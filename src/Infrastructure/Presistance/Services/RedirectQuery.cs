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

        public async Task<Redirect> Find(int id)
        {
            return await _redirectRepository.FindByIdAsync(id);
        }

        public async Task<Redirect> Find(string url)
        {
            return await _redirectRepository.FindByUrlAsync(url);
        }
    }
}