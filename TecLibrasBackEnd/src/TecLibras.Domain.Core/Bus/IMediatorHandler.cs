using System.Threading.Tasks;
using TecLibras.Domain.Core.Commands;
using TecLibras.Domain.Core.Events;


namespace TecLibras.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
