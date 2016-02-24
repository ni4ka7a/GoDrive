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

        public IQueryable<User> GetAllWithDeleted()
        {
            return this.users
                 .AllWithDeleted();
        }

        public void Update(User user)
        {
            var userToUpdate = this.users
                .AllWithDeleted()
                .Where(x => x.Id == user.Id)
                .FirstOrDefault();

            if (userToUpdate != null)
            {
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Age = user.Age;

                this.users.Save();
            }
        }

        public void Delete(string id)
        {
            var userToDelete = this.users
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (userToDelete != null)
            {
                if (userToDelete.OrganizationId != null)
                {
                    var organizationToDelete = this.organizations
                        .All()
                        .Where(x => x.Id == userToDelete.OrganizationId)
                        .FirstOrDefault();

                    if (organizationToDelete != null)
                    {
                        this.organizations.Delete(organizationToDelete);
                        this.organizations.Save();
                    }
                }

                this.users.HardDelete(userToDelete);
                this.users.Save();
            }
        }
    }
}
