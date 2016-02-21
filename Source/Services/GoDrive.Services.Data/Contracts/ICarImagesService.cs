namespace GoDrive.Services.Data.Contracts
{
    using System.Linq;
    using GoDrive.Data.Models;

    public interface ICarImagesService
    {
        IQueryable<CarImage> GetImagesForOrganization(int organizationId);

        void Add(CarImage image);

        void Delete(int id, int organizationId);
    }
}
