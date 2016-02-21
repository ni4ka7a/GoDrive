namespace GoDrive.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using GoDrive.Data.Common;
    using GoDrive.Data.Models;

    public class CarImagesService : ICarImagesService
    {
        private IDbRepository<CarImage> carImages;

        public CarImagesService(IDbRepository<CarImage> carImages)
        {
            this.carImages = carImages;
        }

        public void Add(CarImage image)
        {
            this.carImages.Add(image);
            this.carImages.Save();
        }

        public void Delete(int id, int organizationId)
        {
            var carImage = this.carImages.GetById(id);

            if (carImage.OrganizationId == organizationId)
            {
                this.carImages.Delete(carImage);
                this.carImages.Save();
            }
        }

        public IQueryable<CarImage> GetImagesForOrganization(int organizationId)
        {
            return this.carImages
                .All()
                .Where(c => c.OrganizationId == organizationId);
        }
    }
}
