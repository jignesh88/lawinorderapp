using System;
using LawInOrderApp.Domain.Validations;
namespace LawInOrderApp.Domain.Commands
{
    public class CreateNewTimeSheetCommand : 
    TimeSheetCommand
    {
        public CreateNewTimeSheetCommand( DateTime dateWorked, 
                                         int hourWorked, Guid userId)
        {
            DateWorked = dateWorked;
            HoursWorked = hourWorked;
            UserId = userId;
        }

        public override bool IsValid()
        {
            validationResult = new CreateNewTimeSheetValidation().Validate(this);
            return validationResult.IsValid;
        }
    }
}
