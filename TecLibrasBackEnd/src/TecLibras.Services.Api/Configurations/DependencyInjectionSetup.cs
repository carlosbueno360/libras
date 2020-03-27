using System;
using TecLibras.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace TecLibras.Services.Api.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}