namespace GoDrive.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data.Contracts;

    public class HomeController : BaseController
    {
        private IOrganizationsService organizations;

        public HomeController(IOrganizationsService organizations)
        {
            this.organizations = organizations;
        }

        public ActionResult Index()
        {
            var organizations = this.organizations
                .GetALl()
                .ToList();

            return this.View(organizations);
        }
    }
}
