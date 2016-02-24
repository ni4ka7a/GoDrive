namespace GoDrive.Web.Controllers
{
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.ApplyForOrganization;

    [Authorize]
    public class ApplyForOrganizationController : BaseController
    {
        private ICreateOrganizationRequestsService createOrganizationRequests;

        public ApplyForOrganizationController(ICreateOrganizationRequestsService createOrganizationRequests)
        {
            this.createOrganizationRequests = createOrganizationRequests;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Apply(CreateOrganizationRequestViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var request = this.Mapper.Map<CreateOrganizationRequest>(model);

                request.UserId = userId;

                this.createOrganizationRequests.CreateRequest(request);
                return this.RedirectToAction(x => x.ApplicationSuccess());
            }

            return this.View("Index", model);
        }

        public ActionResult ApplicationSuccess()
        {
            return this.View();
        }
    }
}
