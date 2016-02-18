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

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }
    }
}
