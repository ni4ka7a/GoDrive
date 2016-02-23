namespace GoDrive.Services.Data.Contracts
{
    using System.Linq;
    using GoDrive.Data.Models;

    public interface IOrganizationsService
    {
        IQueryable<Organization> GetALl();

        IQueryable<Organization> GetById(int id);

        bool Create(Organization organization);

        void Update(Organization organization);

        bool AddUser(string userId, string organizationIdString);

        IQueryable<Organization> GetTopOrganizations(int topCount);
    }
}
