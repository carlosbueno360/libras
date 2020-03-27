using System;
using System.Threading;
using System.Threading.Tasks;
using TecLibras.Domain.Commands;
using TecLibras.Domain.Core.Bus;
using TecLibras.Domain.Core.Notifications;
using TecLibras.Domain.Events;
using TecLibras.Domain.Interfaces;
using TecLibras.Domain.Models;
using MediatR;

namespace TecLibras.Domain.CommandHandlers
{
    public class PointsCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewPointsCommand, bool>
    {
        private readonly IPointsRepository _pointsRepository;
        private readonly IMediatorHandler Bus;

        public PointsCommandHandler(IPointsRepository pointsRepository, 
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _pointsRepository = pointsRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewPointsCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var points = new Points(Guid.NewGuid());

            // if (_pointsRepository.GetByEmail(points.Email) != null)
            // {
            //     Bus.RaiseEvent(new DomainNotification(message.MessageType, "The points e-mail has already been taken."));
            //     return Task.FromResult(false);
            // }
            
            _pointsRepository.Add(points);

            if (Commit())
            {
                Bus.RaiseEvent(new PointsRegisteredEvent(points.Id, points.points));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _pointsRepository.Dispose();
        }
    }
}