namespace GoDrive.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using GoDrive.Data.Common;
    using GoDrive.Data.Models;

    public class OrganizationsService : IOrganizationsService
    {
        private IDbRepository<Organization> organizations;
        private IDbRepository<User> users;

        public OrganizationsService(IDbRepository<Organization> organizations, IDbRepository<User> users)
        {
            this.organizations = organizations;
            this.users = users;
        }

        public IQueryable<Organization> GetALl()
        {
            return this.organizations.All();
        }

        public IQueryable<Organization> GetById(int id)
        {
            return this.organizations
                .All()
                .Where(o => o.Id == id);
        }

        public void Create(Organization organization)
        {
            this.organizations.Add(organization);
            this.organizations.Save();
        }

        public void Update(Organization organization)
        {
            var organizationToUpdate = this.organizations.GetById(organization.Id);

            organizationToUpdate.AboutInfo = organization.AboutInfo;
            organizationToUpdate.Name = organization.Name;

            if (organization.OrganizationImage != null)
            {
                organizationToUpdate.OrganizationImage = organization.OrganizationImage;
            }

            this.organizations.Save();
        }

        public void AddUser(string userId, int organizationId)
        {
            var user = this.users
                .All()
                .Where(x => x.Id == userId)
                .FirstOrDefault();

            user.IsInOrganization = true;
            var organization = this.organizations
                .GetById(organizationId);

            organization.Students.Add(user);
            this.organizations.Save();
        }
    }
}
