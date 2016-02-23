namespace GoDrive.Common.Tests.Fakes
{
    using Services.Data.Contracts;
    using System;
    using Data.Models;
    using System.Linq;
    using Data.Common;
    using System.Collections.Generic;

    public class FakeOrganizationsService : IOrganizationsService
    {
        private IList<Organization> organizations = new List<Organization>();
        private IList<User> users = new List<User>();

        public FakeOrganizationsService()
        {
            this.SeedFakes();
        }

        public bool AddUser(string userId, string organizationIdString)
        {
            throw new NotImplementedException();
        }

        public bool Create(Organization organization)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Organization> GetAll()
        {
            return this.organizations.AsQueryable();
        }

        public IQueryable<Organization> GetAllWithDeleted()
        {
            return this.organizations.AsQueryable();
        }

        public IQueryable<Organization> GetById(int id)
        {
            return this.organizations
                .Where(x => x.Id == id)
                .AsQueryable();
        }

        public IQueryable<Organization> GetTopOrganizations(int topCount)
        {
            return this.organizations
                .Take(3)
                .AsQueryable();
        }

        public void Update(Organization organization)
        {
            throw new NotImplementedException();
        }


        private void SeedFakes()
        {
            var users = new List<User>()
            {
                new User
                {
                    Id = "1",
                    Email = "pesho1",
                    UserName = "pesho1"
                },
                new User
                {
                    Id = "1",
                    Email = "pesho2",
                    UserName = "pesho2"
                }
            };

            var carImages = new List<CarImage>()
            {
                new CarImage()
                {
                    Url = "car image url"
                }
            };

            for (int i = 0; i < 5; i++)
            {
                this.organizations.Add(new Organization()
                {
                    Id = 1,
                    AboutInfo = $"info {i}",
                    Name = $"name {i}",
                    OrganizationImage = new OrganizationImage()
                    {
                        Url = $"some image {i}"
                    },
                    Students = users,
                    CreatedOn = DateTime.Now,
                    CarsImages = carImages
                });
            }
        }
    }
}
