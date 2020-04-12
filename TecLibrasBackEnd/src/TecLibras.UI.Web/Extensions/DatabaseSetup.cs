using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TecLibras.UI.Web.Models;

namespace TecLibras.UI.Web.Extensions
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

             //services.AddDbContext<TecLibrasContext>(options =>
             //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // services.AddDbContext<EventStoreSqlContext>(options =>
            //     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}