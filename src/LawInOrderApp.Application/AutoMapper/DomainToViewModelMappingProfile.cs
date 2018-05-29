using AutoMapper;
using LawInOrderApp.Application.ViewModels;
using LawInOrderApp.Domain.Models;

namespace LawInOrderApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<TimeSheet, TimeSheetViewModel>();
        }
    }
}
