namespace GoDrive.Services.Data.Contracts
{
    using System.Linq;
    using GoDrive.Data.Models;

    public interface ICreateOrganizationRequestsService
    {
        void CreateRequest(CreateOrganizationRequest request);

        IQueryable<CreateOrganizationRequest> GetUnProceededRequests();

        IQueryable<CreateOrganizationRequest> GetProceededRequests();

        void ProceedRequest(int id);
    }
}
