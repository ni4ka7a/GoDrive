namespace GoDrive.Web.Areas.MyOrganization.Controllers
{
    using System.Web.Mvc;
    using Services.Data.Contracts;
    using Web.Controllers;

    public class ManageRequestsController : BaseController
    {
        private IJoinOrganizationService joinOrganizationRequests;

        public ManageRequestsController(IJoinOrganizationService joinOrganizationRequests)
        {
            this.joinOrganizationRequests = joinOrganizationRequests;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult GetUnProceedRequest()
        {
            return this.PartialView("_UsersRequestPartial");
        }

        public ActionResult GetProceedRequest()
        {
            return this.PartialView("_UsersRequestPartial");
        }
    }
}