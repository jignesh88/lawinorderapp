using System;
using LawInOrderApp.Domain.Core.Commands;
namespace LawInOrderApp.Domain.Commands
{
    public abstract class TimeSheetCommand : Command
    {
        public Guid Id { get; protected set; }
        public DateTime DateWorked { get; protected set; }
        public int HoursWorked { get; protected set; }
        public Guid UserId { get; protected set; }
    }
}
