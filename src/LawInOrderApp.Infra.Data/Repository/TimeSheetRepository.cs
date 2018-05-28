using System;
using System.Linq;
using LawInOrderApp.Domain.Interfaces;
using LawInOrderApp.Domain.Models;
using LawInOrderApp.Infra.Data.Context;

namespace LawInOrderApp.Infra.Data.Repository
{
    public class TimeSheetRepository: Repository<TimeSheet>, ITimeSheetRepository
    {
        public TimeSheetRepository(LawInOrderAppContext context)
            : base(context)
        {

        }


    }
}
