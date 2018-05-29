using AutoMapper;
using LawInOrderApp.Application.ViewModels;
using LawInOrderApp.Domain.Models;

namespace LawInOrderApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TimeSheetViewModel, TimeSheet >();
        }
    }
}
