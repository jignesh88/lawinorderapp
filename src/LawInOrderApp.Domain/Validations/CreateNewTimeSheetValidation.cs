using System;
using LawInOrderApp.Domain.Commands;
namespace LawInOrderApp.Domain.Validations
{
    public class CreateNewTimeSheetValidation :
    TimeSheetValidation<CreateNewTimeSheetCommand>
    {
        public CreateNewTimeSheetValidation()
        {
            ValidateDate();
            ValidateHourWork();
        }
    }
}
