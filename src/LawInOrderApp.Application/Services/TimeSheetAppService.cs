using System;
using System.Collections.Generic;
using LawInOrderApp.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LawInOrderApp.Application.ViewModels;
using LawInOrderApp.Domain.Commands;
using LawInOrderApp.Domain.Core;
using LawInOrderApp.Domain.Core.Bus;
using LawInOrderApp.Domain.Interfaces;
using LawInOrderApp.Infra.Data.Repository;
using LawInOrderApp.Infra.Data.Repository.EventSourcing;

namespace LawInOrderApp.Application.Services
{
    public class TimeSheetAppService : ITimeSheetAppService
    {
        private readonly IMapper _mapper;
        private readonly ITimeSheetRepository _timeSheetRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _bus;

        public TimeSheetAppService(
            IMapper mapper,
            ITimeSheetRepository timeSheetRepository,
            IEventStoreRepository eventStoreRepository,
            IMediatorHandler bus
        )
        {
            _mapper = mapper;
            _timeSheetRepository = timeSheetRepository;
            _eventStoreRepository = eventStoreRepository;
            _bus = bus;
        }

        public void Create(TimeSheetViewModel timeSheetViewModel)
        {
            var createCommand = _mapper.Map<CreateNewTimeSheetCommand>(timeSheetViewModel);
            _bus.SendCommand(createCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TimeSheetViewModel> GetAll(string role)
        {
            return _timeSheetRepository
                .GetAll().ProjectTo<TimeSheetViewModel>();
                

        }
    }
}
