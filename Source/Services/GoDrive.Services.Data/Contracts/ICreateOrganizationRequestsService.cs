namespace GoDrive.Services.Data.Contracts
{
    using GoDrive.Data.Models;

    public interface ICreateOrganizationRequestsService
    {
        void CreateRequest(CreateOrganizationRequest request);
    }
}
