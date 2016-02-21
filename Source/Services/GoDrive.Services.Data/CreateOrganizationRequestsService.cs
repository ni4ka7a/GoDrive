namespace GoDrive.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using GoDrive.Data.Common;
    using GoDrive.Data.Models;

    public class CreateOrganizationRequestsService : ICreateOrganizationRequestsService
    {
        private IDbRepository<CreateOrganizationRequest> createOrganizationRequests;

        public CreateOrganizationRequestsService(IDbRepository<CreateOrganizationRequest> createOrganizationRequests)
        {
            this.createOrganizationRequests = createOrganizationRequests;
        }

        public void CreateRequest(CreateOrganizationRequest request)
        {
            this.createOrganizationRequests.Add(request);
            this.createOrganizationRequests.Save();
        }

        public IQueryable<CreateOrganizationRequest> GetProceededRequests()
        {
            return this.createOrganizationRequests
                .All()
                .Where(x => x.IsProceed == true);
        }

        public IQueryable<CreateOrganizationRequest> GetUnProceededRequests()
        {
            return this.createOrganizationRequests
                .All()
                .Where(x => x.IsProceed == false);
        }
    }
}
