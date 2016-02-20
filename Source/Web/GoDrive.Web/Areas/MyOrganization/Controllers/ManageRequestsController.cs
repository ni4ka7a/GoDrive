namespace GoDrive.Web.Areas.MyOrganization.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels;
    using Web.Controllers;

    public class ManageRequestsController : BaseController
    {
        private IJoinOrganizationService joinOrganizationRequests;
        private IUsersService users;

        public ManageRequestsController(IJoinOrganizationService joinOrganizationRequests, IUsersService users)
        {
            this.joinOrganizationRequests = joinOrganizationRequests;
            this.users = users;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult GetUnProceedRequest()
        {
            var userId = this.User.Identity.GetUserId();
            var organizationId = this.users
                .GetAll()
                .Where(x => x.Id == userId)
                .FirstOrDefault()
                .OrganizationId;

            var requests = this.joinOrganizationRequests
                .GetUnProceededRequests((int)organizationId)
                .To<UserRequestViewModel>()
                .ToList();

            return this.PartialView("_UsersRequestPartial", requests);
        }

        public ActionResult GetProceedRequest()
        {
            var userId = this.User.Identity.GetUserId();
            var organizationId = this.users
                .GetAll()
                .Where(x => x.Id == userId)
                .FirstOrDefault()
                .OrganizationId;

            var requests = this.joinOrganizationRequests
                .GetProceededRequests((int)organizationId)
                .To<UserRequestViewModel>()
                .ToList();

            return this.PartialView("_UsersRequestPartial", requests);
        }
    }
}