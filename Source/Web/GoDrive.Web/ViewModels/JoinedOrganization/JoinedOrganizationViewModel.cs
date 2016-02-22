namespace GoDrive.Web.ViewModels.JoinedOrganization
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class JoinedOrganizationViewModel : IMapFrom<Organization>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AboutInfo { get; set; }
    }
}