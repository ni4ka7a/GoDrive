namespace GoDrive.Common.Tests.Fakes
{
    using System;
    using Data.Models;
    using Services.Data.Contracts;

    public class FakeOrganizationImagesService : IOrganizationImagesService
    {
        public OrganizationImage GetDefaultImage()
        {
            throw new NotImplementedException();
        }

        public bool ValidateFileExtention(string extension)
        {
            throw new NotImplementedException();
        }
    }
}
