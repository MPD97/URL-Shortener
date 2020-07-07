using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Installers
{
    public interface IInstaler
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration);

    }
}