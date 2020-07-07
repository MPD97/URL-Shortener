using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presistance.Services;

namespace API.Installers
{
    public class ServicesInstaller : IInstaller{
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRedirectExtendedQuery, RedirectExtendedQuery>();
            services.AddScoped<IRedirectQuery, RedirectQuery>();
            services.AddScoped<IShortcutAdmin, ShortcutAdmin>();
            services.AddScoped<IShortcutQuery, ShortcutQuery>();
        }
    }
}