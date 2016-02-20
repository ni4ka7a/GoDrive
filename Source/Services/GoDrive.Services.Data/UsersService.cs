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

        public UsersService(IDbRepository<User> users)
        {
            this.users = users;
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
    }
}
