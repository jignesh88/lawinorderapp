using System;
using LawInOrderApp.Application.Interfaces;
using LawInOrderApp.Application.ViewModels;
using LawInOrderApp.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LawInOrderApp.UI.Site.Controllers
{


    public class TimeSheetController : BaseController
    {
        private readonly ITimeSheetAppService _timeSheetAppService;

        public TimeSheetController(ITimeSheetAppService timeSheetAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _timeSheetAppService = timeSheetAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("timesheets/list-all")]
        public IActionResult Index()
        {
            return View(_timeSheetAppService.GetAll(""));
        }


        [HttpGet]
        [Route("timesheets/create-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("timesheets/create-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TimeSheetViewModel timeSheetViewModel)
        {
            if (!ModelState.IsValid) return View(timeSheetViewModel);
            _timeSheetAppService.Create(timeSheetViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "TimeSheet Created!";

            return View(timeSheetViewModel);
        }
    }
}
