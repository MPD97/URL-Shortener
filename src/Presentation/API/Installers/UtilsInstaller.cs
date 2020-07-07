using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presistance.Services;

namespace API.Installers
{
    public class UtilsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAliasGenerator, AliasGenerator>();
        }
    }
}