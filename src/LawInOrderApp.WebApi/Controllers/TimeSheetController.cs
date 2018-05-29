using System;
using LawInOrderApp.Application.Interfaces;
using LawInOrderApp.Application.ViewModels;
using LawInOrderApp.Domain.Core.Bus;
using LawInOrderApp.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LawInOrderApp.WebApi.Controllers
{
    
    [Authorize]
    public class TimeSheetController : ApiController
    {
        private readonly ITimeSheetAppService _timeSheetAppService;

        public TimeSheetController(
            ITimeSheetAppService timeSheetAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _timeSheetAppService = timeSheetAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("timesheets")]
        public IActionResult Get()
        {
            return Response(_timeSheetAppService.GetAll(""));
        }

        [HttpPost]
        [Authorize(Policy = "CanCreateTimeSheet")]
        [Route("timesheets")]
        public IActionResult Post([FromBody]TimeSheetViewModel timeSheetViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(timeSheetViewModel);
            }

            _timeSheetAppService.Create(timeSheetViewModel);

            return Response(timeSheetViewModel);
        }
    }
}
