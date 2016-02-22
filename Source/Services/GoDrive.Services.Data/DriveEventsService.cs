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
            throw new NotImplementedException();
        }

        public void Delete(DriveEvent driveEvent)
        {
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
            throw new NotImplementedException();
        }
    }
}
