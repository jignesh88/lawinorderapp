using System;
using LawInOrderApp.Domain.Core.Commands;
using LawInOrderApp.Domain.Core.Bus;
using LawInOrderApp.Domain.Core.Notifications;
using MediatR;
using LawInOrderApp.Domain.Interfaces;

namespace LawInOrderApp.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork unitOfWork,
                             IMediatorHandler mediator,
                              INotificationHandler<DomainNotification> notifications)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler) notifications;
        }

        protected void NotifyValidationErrors(Command message){
            foreach (var error in message.validationResult.Errors)
            {
                
                _mediator.RaiseEvent(new DomainNotification(message.MessageType,
                                                       error.ErrorMessage));
            }
        }

        public bool Commit(){
            if (_notifications.HasNotifications()) return false;

            if(_unitOfWork.commit()) return true;

            _mediator.RaiseEvent(new DomainNotification("Commit", "We had problem when saving data"));
            return false;
        }
    }
}
