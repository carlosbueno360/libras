using System;
using Microsoft.AspNetCore.Authorization;
using TecLibras.Services.Api.Context;
using Microsoft.Extensions.DependencyInjection;
using TecLibras.Services.Api.Authorization;
using TecLibras.Services.Api.Models;
using TecLibras.Services.Api.Repositories;
using TecLibras.Services.Api.Model;

namespace TecLibras.Services.Api.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            RegisterServices(services);
        }

        
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Infra - Data
            services.AddScoped<IPointEventRepository, PointEventRepository>();
            services.AddScoped<IRankRepository, RankRepository>();
            services.AddScoped<IQuestionsRepository, QuestionsRepository>();
            services.AddScoped<IUserApplicationRepository, UserApplicationRepository>();
            
            services.AddScoped<ApplicationDbContext>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }

    }
}