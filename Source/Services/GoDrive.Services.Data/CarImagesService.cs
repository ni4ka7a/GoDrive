namespace GoDrive.Services.Data
{
    using System;
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
    }
}
