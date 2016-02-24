namespace GoDrive.Web.Areas.MyOrganization.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class ManageUserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
