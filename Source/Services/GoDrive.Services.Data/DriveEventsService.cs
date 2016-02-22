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
        private IDbRepository<User> users;

        public DriveEventsService(IDbRepository<DriveEvent> driveEvents, IDbRepository<User> users)
        {
            this.driveEvents = driveEvents;
            this.users = users;
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

        public IQueryable<DriveEvent> GetEventsByOrganization(string userId)
        {
            var organizationId = this.users
                .All()
                .Where(x => x.Id == userId)
                .FirstOrDefault()
                .OrganizationId;

            return this.driveEvents
                .All()
                .Where(x => x.OrganizationId == organizationId);
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
