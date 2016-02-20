namespace GoDrive.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using GoDrive.Data.Common;
    using GoDrive.Data.Models;

    public class JoinOrganizationService : IJoinOrganizationService
    {
        private IDbRepository<JoinOrganizationRequest> joinOrganizationRequests;
        private IDbRepository<User> users;

        public JoinOrganizationService(
            IDbRepository<JoinOrganizationRequest> joinOrganizationRequests,
            IDbRepository<User> users)
        {
            this.joinOrganizationRequests = joinOrganizationRequests;
            this.users = users;
        }

        public bool CannotJoinOrganization(string userId)
        {
            var user = this.users
                .All()
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            if (user == null)
            {
                return false;
            }

            if (user.IsInOrganization == true || user.OrganizationId != null)
            {
                return false;
            }

            var hasApplied = this.joinOrganizationRequests
                .All()
                .Where(u => u.IsProceed == false)
                .Any(u => u.UserId == userId);

            if (hasApplied)
            {
                return false;
            }

            return true;
        }

        public void CreateRequest(JoinOrganizationRequest request)
        {
            this.joinOrganizationRequests.Add(request);
            this.joinOrganizationRequests.Save();
        }

        public IQueryable<JoinOrganizationRequest> GetProceededRequests(int organizationId)
        {
            return this.joinOrganizationRequests
                .All()
                .Where(x => x.OrganizationId == organizationId)
                .Where(x => x.IsProceed == true);
        }

        public IQueryable<JoinOrganizationRequest> GetUnProceededRequests(int organizationId)
        {
            return this.joinOrganizationRequests
                .All()
                .Where(x => x.OrganizationId == organizationId)
                .Where(x => x.IsProceed == false);
        }

        public void ProceedUserRequest(int id)
        {
            var request = this.joinOrganizationRequests
                .GetById(id);

            request.IsProceed = true;

            this.joinOrganizationRequests.Save();
        }
    }
}
