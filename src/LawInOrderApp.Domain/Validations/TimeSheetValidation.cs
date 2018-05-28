using System;
using LawInOrderApp.Domain.Commands;
using FluentValidation;
namespace LawInOrderApp.Domain.Validations
{
    public abstract class TimeSheetValidation<T> : 
    AbstractValidator<T> where T : TimeSheetCommand
    {
        // Hours worked must be greater than 0 and not null
        protected void ValidateHourWork(){
            RuleFor(t => t.HoursWorked)
                .NotEmpty()
                .GreaterThan(0);

        }

        // Date must be not null
        protected void ValidateDate()
        {
            RuleFor(t => t.DateWorked)
                .NotEmpty();
        }
    }
}
