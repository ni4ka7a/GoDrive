namespace GoDrive.Services.Data.Contracts
{
    using System.Linq;
    using GoDrive.Data.Models;

    public interface IDriveEventsService
    {
        IQueryable<DriveEvent> GetAll();

        void Update(DriveEvent driveEvent);

        void Create(DriveEvent driveEvent, string organizationOwnerId);

        void Delete(int driveEventId);

        IQueryable<DriveEvent> GetEventsByOrganization(string userId);

        IQueryable<DriveEvent> GetEventsByUser(string userId);
    }
}
