using System;
using System.Collections.Generic;
using System.Linq;
using LawInOrderApp.Domain.Core.Events;
using Newtonsoft.Json;

namespace LawInOrderApp.Application.EventSourceNormalizer
{
    public class TimeSheetHistory
    {
        public static IList<TimeSheetHistoryData> HistoryData { get; set; }

        public static IList<TimeSheetHistoryData> ToJavaScriptTimeSheetHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<TimeSheetHistoryData>();
            CustomerHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<TimeSheetHistoryData>();
            var last = new TimeSheetHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new TimeSheetHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    HourWorked = string.IsNullOrWhiteSpace(change.HourWorked) || change.HourWorked == last.HourWorked
                        ? ""
                                       : change.HourWorked,
                    DateWorked = string.IsNullOrWhiteSpace(change.DateWorked) || change.DateWorked == last.DateWorked
                        ? ""
                                       : change.DateWorked,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void CustomerHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new TimeSheetHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "CrateTimeSheetEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.HourWorked = values["HourWorked"];
                        slot.DateWorked = values["DateWorked"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
