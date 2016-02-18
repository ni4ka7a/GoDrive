namespace GoDrive.Services.Data.Contracts
{
    using System.Linq;
    using GoDrive.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();
    }
}
