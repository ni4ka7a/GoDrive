namespace GoDrive.Services.Data.Contracts
{
    using System.Linq;
    using GoDrive.Data.Models;

    public interface IJoinOrganizationService
    {
        void CreateRequest(JoinOrganizationRequest request);

        bool CannotJoinOrganization(string userId);

        IQueryable<JoinOrganizationRequest> GetUnProceededRequests(int organizationId);

        IQueryable<JoinOrganizationRequest> GetProceededRequests(int organizationId);

        void ProceedUserRequest(int id);
    }
}
