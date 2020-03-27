using System;
using TecLibras.Infra.CrossCutting.Identity.Authorization;
using TecLibras.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TecLibras.UI.Web.Extensions
{
    public static class IdentitySetup
    {
        public static void AddIdentitySetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }

        public static void AddAuthSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAuthentication()
                .AddFacebook(o =>
                {
                    o.AppId = configuration["Authentication:Facebook:AppId"];
                    o.AppSecret = configuration["Authentication:Facebook:AppSecret"];
                })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanWritePointsData", policy => policy.Requirements.Add(new ClaimRequirement("Pointss", "Write")));
                options.AddPolicy("CanRemovePointsData", policy => policy.Requirements.Add(new ClaimRequirement("Pointss", "Remove")));
            });
        }
    }
}