using System;
using LawInOrderApp.Domain.Core.Events;

namespace LawInOrderApp.Domain.Events
{
    public class TimeSheetCreatedEvent : Event
    {
        public TimeSheetCreatedEvent(Guid id, 
                                    int hoursWorked,
                                     DateTime dateWorked,
                                     Guid userId)
        {
            Id = id;
            HoursWorked = hoursWorked;
            DateWorked = dateWorked;
            UserId = userId;
        }

        public Guid Id { get; set; }
        public int HoursWorked { get; private set; }
        public DateTime DateWorked { get; private set; }
        public Guid UserId { get; private set; }
    }
}
