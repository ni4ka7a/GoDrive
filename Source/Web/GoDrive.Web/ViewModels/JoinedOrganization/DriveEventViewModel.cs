namespace GoDrive.Web.ViewModels.JoinedOrganization
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.UI;

    public class DriveEventViewModel : IMapFrom<DriveEvent>, ISchedulerEvent
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool IsAllDay { get; set; }

        public string UserID { get; set; }

        public string Description { get; set; }

        public string StartTimezone { get; set; }

        public string EndTimezone { get; set; }

        public string RecurrenceRule { get; set; }

        public string RecurrenceException { get; set; }
    }
}
