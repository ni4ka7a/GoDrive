namespace GoDrive.Services.Data
{
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
    }
}
