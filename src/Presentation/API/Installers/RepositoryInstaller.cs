using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presistance.Repositories;

namespace API.Installers
{
    public class RepositoryInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRedirectExtendedRepository, RedirectExtendedEfRepository>();
            services.AddScoped<IRedirectRepository, RedirectEfRepository>();
            services.AddScoped<IShortcutRepository, ShortcutEfRepository>();
        }
    }
}