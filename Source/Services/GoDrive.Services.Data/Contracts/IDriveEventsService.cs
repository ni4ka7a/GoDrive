namespace GoDrive.Services.Data.Contracts
{
    using GoDrive.Data.Models;
    using System.Linq;

    public interface IDriveEventsService
    {
        IQueryable<DriveEvent> GetAll();

        void Update(DriveEvent driveEvent);

        void Create(DriveEvent driveEvent);

        void Delete(DriveEvent driveEvent);
    }
}
