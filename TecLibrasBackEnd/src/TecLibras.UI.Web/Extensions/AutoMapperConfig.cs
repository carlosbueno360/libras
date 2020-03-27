using System;
using AutoMapper;
using TecLibras.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace TecLibras.UI.Web.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}