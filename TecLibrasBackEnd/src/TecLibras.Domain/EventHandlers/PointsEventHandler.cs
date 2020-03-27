using System.Threading;
using System.Threading.Tasks;
using TecLibras.Domain.Events;
using MediatR;

namespace TecLibras.Domain.EventHandlers
{
    public class PointsEventHandler :
        INotificationHandler<PointsRegisteredEvent>
    {

        public Task Handle(PointsRegisteredEvent message, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }
        
    }
}