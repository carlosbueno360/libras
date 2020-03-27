using TecLibras.Application.Interfaces;
using TecLibras.Application.Services;
using TecLibras.Domain.CommandHandlers;
using TecLibras.Domain.Commands;
using TecLibras.Domain.Core.Bus;
using TecLibras.Domain.Core.Events;
using TecLibras.Domain.Core.Notifications;
using TecLibras.Domain.EventHandlers;
using TecLibras.Domain.Events;
using TecLibras.Domain.Interfaces;
using TecLibras.Infra.CrossCutting.Bus;
using TecLibras.Infra.CrossCutting.Identity.Authorization;
using TecLibras.Infra.CrossCutting.Identity.Models;
using TecLibras.Infra.Data.Context;
using TecLibras.Infra.Data.EventSourcing;
using TecLibras.Infra.Data.Repository;
using TecLibras.Infra.Data.Repository.EventSourcing;
using TecLibras.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace TecLibras.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IPointsAppService, PointsAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<PointsRegisteredEvent>, PointsEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewPointsCommand, bool>, PointsCommandHandler>();

            // Infra - Data
            services.AddScoped<IPointsRepository, PointsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<TecLibrasContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}