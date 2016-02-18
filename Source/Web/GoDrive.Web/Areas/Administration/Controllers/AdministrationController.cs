namespace GoDrive.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using GoDrive.Common;
    using GoDrive.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult CreateOrganization()
        {
            return this.View();
        }
    }
}
