using System;
using System.Threading.Tasks;
using LawInOrderApp.Domain.Core.Commands;
using LawInOrderApp.Domain.Core.Events;
namespace LawInOrderApp.Domain.Core.Bus
{
    public interface IMediatorHandler
    {

        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T theEvent) where T : Event;
    }
}
