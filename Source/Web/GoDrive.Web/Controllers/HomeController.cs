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
            var org = this.organizations.GetALl()
                .Select(o => o.User)
                .ToList();
            return this.View();
        }
    }
}
