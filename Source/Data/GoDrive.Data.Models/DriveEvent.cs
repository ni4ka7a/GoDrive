namespace GoDrive.Data.Models
{
    using System;
    using Common.Models;

    public class DriveEvent : BaseModel<int>
    {
        public string Title { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool IsAllDay { get; set; }

        public string UserID { get; set; }

        public User User { get; set; }
    }
}
