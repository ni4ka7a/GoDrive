namespace GoDrive.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Home;
    using ViewModels.Organizations;

    public class HomeController : BaseController
    {
        private IOrganizationsService organizations;

        public HomeController(IOrganizationsService organizations)
        {
            this.organizations = organizations;
        }

        public ActionResult Index()
        {
            var topOrganizations = this.organizations
                .GetALl()
                .To<OrganizationViewModel>()
                .ToList();

            var model = new IndexViewModel()
            {
                Organizations = topOrganizations
            };

            return this.View(model);
        }
    }
}
