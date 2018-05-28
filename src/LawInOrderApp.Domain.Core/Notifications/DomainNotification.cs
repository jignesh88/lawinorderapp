using System;
using LawInOrderApp.Domain.Core.Events;

namespace LawInOrderApp.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public Guid DomainNotificationID { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationID = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
        }
    }
}
