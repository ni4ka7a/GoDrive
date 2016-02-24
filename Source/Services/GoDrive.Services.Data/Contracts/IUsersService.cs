namespace GoDrive.Services.Data.Contracts
{
    using System.Linq;
    using GoDrive.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        IQueryable<User> GetAllWithDeleted();

        void Update(User user);

        void Delete(string id);

        void AddOrganization(string userId, Organization organization);

        IQueryable<User> GetUsersForOrganization(string userId);
    }
}
