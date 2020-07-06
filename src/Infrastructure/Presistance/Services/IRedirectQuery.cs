using System.Threading.Tasks;
using Core.Entities;

namespace Presistance.Services
{
    public interface IRedirectQuery
    {
        public Task<Redirect> Find(int id);
        public Task<Redirect> Find(string url);
    }
}