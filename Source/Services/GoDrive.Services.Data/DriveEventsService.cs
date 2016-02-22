namespace GoDrive.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using GoDrive.Data.Common;
    using GoDrive.Data.Models;

    public class DriveEventsService : IDriveEventsService
    {
        private IDbRepository<DriveEvent> driveEvents;

        public DriveEventsService(IDbRepository<DriveEvent> driveEvents)
        {
            this.driveEvents = driveEvents;
        }

        public void Create(DriveEvent driveEvent)
        {
            this.driveEvents.Add(driveEvent);
            this.driveEvents.Save();
        }

        public void Delete(int driveEventId)
        {
            var driveEvent = this.driveEvents.GetById(driveEventId);
            if (driveEvent != null)
            {
                this.driveEvents.Delete(driveEvent);
                this.driveEvents.Save();
            }
        }

        public IQueryable<DriveEvent> GetAll()
        {
            return this.driveEvents.All();
        }

        public void Update(DriveEvent driveEvent)
        {
            var eventToUpdate = this.driveEvents
                .GetById(driveEvent.Id);

            if (eventToUpdate != null)
            {
                eventToUpdate.Title = driveEvent.Title;
                eventToUpdate.IsAllDay = driveEvent.IsAllDay;
                eventToUpdate.Start = driveEvent.Start;
                eventToUpdate.End = driveEvent.End;
                eventToUpdate.UserID = driveEvent.UserID;

                this.driveEvents.Save();
            }
        }
    }
}
