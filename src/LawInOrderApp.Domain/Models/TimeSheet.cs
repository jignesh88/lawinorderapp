using System;
using LawInOrderApp.Domain.Core.Models;

namespace LawInOrderApp.Domain.Models
{
    public class TimeSheet : Entity
    {
        
        public int HourWorked { get; private set; }
        public DateTime DateWorked { get; private set; }
        public Guid UserId { get; private set; }

        protected TimeSheet()
        {

        }
        public TimeSheet(Guid id, int hourWorked,
                        DateTime dateWorked,
                        Guid userId)
        {
            Id = id;
            HourWorked = hourWorked;
            DateWorked = dateWorked;
            UserId = userId;
        }
    }
}
