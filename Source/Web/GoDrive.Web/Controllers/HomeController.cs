namespace GoDrive.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Home;
    using ViewModels.Organizations;

    public class HomeController : BaseController
    {
        private IOrganizationsService organizations;
        private IUsersService users;

        public HomeController(IOrganizationsService organizations, IUsersService users)
        {
            this.organizations = organizations;
            this.users = users;
        }

        public ActionResult Index()
        {
            var topOrganizations = this.Cache.Get(
                "topOrganizations",
                () => this.organizations
                .GetTopOrganizations(GlobalConstants.TopOrganizationsCount)
                .To<OrganizationViewModel>()
                .ToList(),
                30 * 60);

            var usersCount = this.Cache.Get(
                "usersCount",
                () => this.users.GetAll().Count(),
                30 * 60);

            var organizationsCount = this.Cache.Get(
                "usersCount",
                () => this.organizations.GetAll().Count(),
                30 * 60);

            var model = new IndexViewModel()
            {
                Organizations = topOrganizations,
                UsersCount = usersCount,
                OrganizationsCount = organizationsCount
            };

            return this.View(model);
        }

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            return this.View();
        }
    }
}
