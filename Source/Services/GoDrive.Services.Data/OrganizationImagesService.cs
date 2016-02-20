namespace GoDrive.Services.Data
{
    using System.Linq;
    using Common;
    using Contracts;
    using GoDrive.Data.Common;
    using GoDrive.Data.Models;

    public class OrganizationImagesService : IOrganizationImagesService
    {
        private IDbRepository<OrganizationImage> organizationImages;

        public OrganizationImagesService(IDbRepository<OrganizationImage> organizationImages)
        {
            this.organizationImages = organizationImages;
        }

        public OrganizationImage GetDefaultImage()
        {
            return this.organizationImages
                .All()
                .Where(i => i.Name == GlobalConstants.DefaultImageName)
                .FirstOrDefault();
        }
    }
}
