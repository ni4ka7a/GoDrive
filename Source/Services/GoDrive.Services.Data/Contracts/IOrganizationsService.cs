namespace GoDrive.Services.Data.Contracts
{
    using System.Linq;
    using GoDrive.Data.Models;

    public interface IOrganizationsService
    {
        IQueryable<Organization> GetALl();

        IQueryable<Organization> GetById(int id);

        void Create(Organization organization);

        void Update(Organization organization);

        void AddUser(string userId, int organizationId);
    }
}
