namespace GoDrive.Web.ViewModels.Organizations
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class OrganizationViewModel : IMapFrom<Organization>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AboutInfo { get; set; }
    }
}