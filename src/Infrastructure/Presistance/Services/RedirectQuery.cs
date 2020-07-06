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

        public Task<Redirect> Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Redirect> Find(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}