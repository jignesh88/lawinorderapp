using System;
using System.Threading;
using System.Threading.Tasks;
using LawInOrderApp.Domain.Commands;
using LawInOrderApp.Domain.Core.Bus;
using LawInOrderApp.Domain.Core.Notifications;
using LawInOrderApp.Domain.Events;
using LawInOrderApp.Domain.Interfaces;
using LawInOrderApp.Domain.Models;
using MediatR;

namespace LawInOrderApp.Domain.CommandHandlers
{
    public class TimeSheetCommandHandler :
    CommandHandler,
    IRequestHandler<CreateNewTimeSheetCommand>
    {
        private readonly ITimeSheetRepository _timeSheetRepository;
        private readonly IMediatorHandler _bus;

        public TimeSheetCommandHandler(
            ITimeSheetRepository timeSheetRepository,
            IUnitOfWork unitOfWork,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications
        ) : base(unitOfWork, bus, notifications)
        {
            _timeSheetRepository = timeSheetRepository;
            _bus = bus;
        }

        public Task Handle(CreateNewTimeSheetCommand message, 
                           CancellationToken cancellationToken){
            
            if(!message.IsValid()){
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var timeSheet = new TimeSheet(Guid.NewGuid(), message.HoursWorked, 
                                          message.DateWorked, message.UserId);

            _timeSheetRepository.Add(timeSheet);

            if(Commit()){
                _bus.RaiseEvent(new TimeSheetCreatedEvent(timeSheet.Id, timeSheet.HourWorked,
                                                          timeSheet.DateWorked,
                                                          timeSheet.UserId));
            }

            return Task.CompletedTask;

        }

        public void Dispose(){
            _timeSheetRepository.Dispose();
        }


    }
}
