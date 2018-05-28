using System;
using LawInOrderApp.Domain.Core.Events;
using FluentValidation.Results;
namespace LawInOrderApp.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult validationResult { get; set; }
        protected Command(){
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
