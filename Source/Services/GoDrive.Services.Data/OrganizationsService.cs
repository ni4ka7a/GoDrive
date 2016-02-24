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
        private IOrganizationImagesService organizationImages;

        public OrganizationsService(
            IDbRepository<Organization> organizations,
            IDbRepository<User> users,
            IOrganizationImagesService organizationImages)
        {
            this.organizations = organizations;
            this.users = users;
            this.organizationImages = organizationImages;
        }

        public IQueryable<Organization> GetAll()
        {
            return this.organizations.All();
        }

        public IQueryable<Organization> GetById(int id)
        {
            return this.organizations
                .All()
                .Where(o => o.Id == id);
        }

        public bool Create(Organization organization)
        {
            var owner = this.users
                .All()
                .Where(x => x.Id == organization.UserId)
                .FirstOrDefault();

            if (owner == null)
            {
                return false;
            }

            if (owner.OrganizationId != null)
            {
                return false;
            }

            organization.OrganizationImage = this.organizationImages.GetDefaultImage();

            owner.Organization = organization;
            this.users.Save();

            return true;
        }

        public void Update(Organization organization)
        {
            var organizationToUpdate = this.organizations.GetById(organization.Id);

            organizationToUpdate.AboutInfo = organization.AboutInfo;
            organizationToUpdate.Name = organization.Name;
            organizationToUpdate.PhoneNumber = organization.PhoneNumber;

            if (organization.OrganizationImage != null)
            {
                organizationToUpdate.OrganizationImage = organization.OrganizationImage;
            }

            this.organizations.Save();
        }

        public bool AddUser(string userId, string organizationIdString)
        {
            int organizationId;

            var organizationExists = int.TryParse(organizationIdString, out organizationId);

            if (!organizationExists)
            {
                return false;
            }

            var user = this.users
                .All()
                .Where(x => x.Id == userId)
                .FirstOrDefault();

            if (user.IsInOrganization == true)
            {
                return false;
            }

            user.IsInOrganization = true;
            var organization = this.organizations
                .GetById(organizationId);

            organization.Students.Add(user);
            this.organizations.Save();

            return true;
        }

        public IQueryable<Organization> GetTopOrganizations(int topCount)
        {
            return this.organizations
                .All()
                .OrderByDescending(x => x.Students.Count())
                .ThenBy(x => x.Name)
                .Take(topCount);
        }

        public IQueryable<Organization> GetAllWithDeleted()
        {
            return this.organizations
                .AllWithDeleted();
        }

        public void Delete(int id)
        {
            var organizationToDelete = this.organizations
                .GetById(id);

            var organizationOwner = this.users
                .All()
                .Where(x => x.Id == organizationToDelete.UserId)
                .FirstOrDefault();

            if (organizationToDelete != null)
            {
                this.organizations.Delete(organizationToDelete);
                this.organizations.Save();
            }

            if (organizationOwner != null)
            {
                organizationOwner.Organization = null;
                organizationOwner.OrganizationId = null;
                this.users.Save();
            }
        }
    }
}
