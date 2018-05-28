using System;
using System.Threading;
using System.Threading.Tasks;
using LawInOrderApp.Domain.Events;
using MediatR;
namespace LawInOrderApp.Domain.EventHandlers
{
    public class TimeSheetEventHandler :
        INotificationHandler<TimeSheetCreatedEvent>
    {

        public Task Handle(TimeSheetCreatedEvent notification,
                           CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
