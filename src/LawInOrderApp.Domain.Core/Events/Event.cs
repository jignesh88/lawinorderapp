using System;
using MediatR;
namespace LawInOrderApp.Domain.Core.Events
{
    public abstract class Event: Message, INotification
    {
        public DateTime Timestamp { get; set; }

        protected Event(){
            Timestamp = DateTime.Now;
        }
    }
}
