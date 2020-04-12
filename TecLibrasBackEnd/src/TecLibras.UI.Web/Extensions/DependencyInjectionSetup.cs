using System;
using Microsoft.Extensions.DependencyInjection;
using TecLibras.UI.Web.Clients;

namespace TecLibras.UI.Web.Extensions
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Clients
            services.AddScoped<IPointsClientApi, PointsClientApi>();
        }
    }
}