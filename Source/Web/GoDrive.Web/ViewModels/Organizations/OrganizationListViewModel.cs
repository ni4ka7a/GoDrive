namespace GoDrive.Web.ViewModels.Organizations
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class OrganizationListViewModel : IMapFrom<Organization>
    {
        public string Name { get; set; }

        public string AboutInfo { get; set; }
    }
}