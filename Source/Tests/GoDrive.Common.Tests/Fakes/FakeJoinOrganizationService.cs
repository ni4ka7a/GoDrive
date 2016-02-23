namespace GoDrive.Common.Tests.Fakes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GoDrive.Data.Models;
    using GoDrive.Services.Data.Contracts;

    public class FakeJoinOrganizationService : IJoinOrganizationService
    {
        private IList<JoinOrganizationRequest> joinOrganizationRequests = new List<JoinOrganizationRequest>();
        private IList<User> users = new List<User>();

        public bool CannotJoinOrganization(string userId)
        {
            return true;
        }

        public void CreateRequest(JoinOrganizationRequest request)
        {
            throw new NotImplementedException();
        }

        public IQueryable<JoinOrganizationRequest> GetProceededRequests(int organizationId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<JoinOrganizationRequest> GetUnProceededRequests(int organizationId)
        {
            throw new NotImplementedException();
        }

        public void ProceedUserRequest(int id)
        {
            throw new NotImplementedException();
        }

        private void SeedFakes()
        {
            this.users.Add(
                new User
                {
                    Id = "1",
                    Email = "pesho1",
                    UserName = "pesho1"
                });

            this.users.Add(
                new User
                {
                    Id = "1",
                    Email = "pesho2",
                    UserName = "pesho2"
                });
        }
    }
}
