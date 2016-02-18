namespace GoDrive.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Organizations;

    public class OrganizationsController : Controller
    {
        private IOrganizationsService organizations;

        public OrganizationsController(IOrganizationsService organizations)
        {
            this.organizations = organizations;
        }

        public ActionResult Index()
        {
            var organizations = this.organizations
                .GetALl()
                .To<OrganizationListViewModel>()
                .ToList();

            return this.View(organizations);
        }
    }
}