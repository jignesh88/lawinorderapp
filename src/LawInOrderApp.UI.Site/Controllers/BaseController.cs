using Microsoft.AspNetCore.Mvc;
using MediatR;
using LawInOrderApp.Domain.Core.Notifications;

namespace LawInOrderApp.UI.Site.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;

        public BaseController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public bool IsValidOperation(){
            return (!_notifications.HasNotifications());
        }
    }
}
