using System;
using System.Collections.Generic;
using LawInOrderApp.Application.EventSourceNormalizer;
using LawInOrderApp.Application.ViewModels;
namespace LawInOrderApp.Application.Interfaces
{
    public interface ITimeSheetAppService : IDisposable
    {
        void Create(TimeSheetViewModel timeSheetViewModel);
        IEnumerable<TimeSheetViewModel> GetAll(string role);
    }
}
