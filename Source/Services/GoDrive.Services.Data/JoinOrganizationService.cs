namespace GoDrive.Services.Data
{
    using System;
    using Contracts;
    using GoDrive.Data.Common;
    using GoDrive.Data.Models;
    using System.Linq;
    public class JoinOrganizationService : IJoinOrganizationService
    {
        private IDbRepository<JoinOrganizationRequest> joinOrganizationRequests;
        private IDbRepository<User> users;

        public JoinOrganizationService(IDbRepository<JoinOrganizationRequest> joinOrganizationRequests, IDbRepository<User> users)
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
    }
}
