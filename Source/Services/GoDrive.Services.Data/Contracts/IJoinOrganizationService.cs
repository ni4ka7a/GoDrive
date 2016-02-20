namespace GoDrive.Services.Data.Contracts
{
    using GoDrive.Data.Models;

    public interface IJoinOrganizationService
    {
        void CreateRequest(JoinOrganizationRequest request);

        bool CannotJoinOrganization(string userId);
    }
}
