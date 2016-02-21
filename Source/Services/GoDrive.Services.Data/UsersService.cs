namespace GoDrive.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using GoDrive.Data.Common;
    using GoDrive.Data.Models;

    public class UsersService : IUsersService
    {
        private IDbRepository<User> users;
        private IDbRepository<Organization> organizations;

        public UsersService(IDbRepository<User> users, IDbRepository<Organization> organizations)
        {
            this.users = users;
            this.organizations = organizations;
        }

        public void AddOrganization(string userId, Organization organization)
        {
            var user = this.users.GetById(userId);
            user.Organization = organization;

            this.users.Save();
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public IQueryable<User> GetUsersForOrganization(string userId)
        {
            var organizationId = this.users
                .All()
                .Where(u => u.Id == userId)
                .FirstOrDefault()
                .OrganizationId;

            return this.users
                .All()
                .Where(u => u.JoinedOrganizationId == organizationId);
        }
    }
}
