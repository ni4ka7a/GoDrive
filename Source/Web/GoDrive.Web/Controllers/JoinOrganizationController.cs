namespace GoDrive.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.JoinOrganization;

    [Authorize]
    public class JoinOrganizationController : BaseController
    {
        private IOrganizationsService organizations;
        private IJoinOrganizationService joinOrganizationRequests;

        public JoinOrganizationController(IOrganizationsService organizations, IJoinOrganizationService joinOrganizationRequests)
        {
            this.organizations = organizations;
            this.joinOrganizationRequests = joinOrganizationRequests;
        }

        public ActionResult Index(int id)
        {
            var userId = this.User.Identity.GetUserId();

            if (this.joinOrganizationRequests.CanJoinOrganization(userId))
            {
                // TODO: rediect to custom page
            }

            var organization = this.organizations
                .GetById(id)
                .FirstOrDefault();

            if (organization == null)
            {
                throw new HttpException(404, "Invalid Organization");
            }

            var organizationModel = new JoinOrganizationViewModel()
            {
                OrganizationId = organization.Id,
                OrganizationName = organization.Name
            };

            return this.View(organizationModel);
        }

        public ActionResult Apply(JoinOrganizationViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var joinOrganizationRequest = this.Mapper.Map<JoinOrganizationRequest>(model);

                joinOrganizationRequest.UserId = userId;
                this.joinOrganizationRequests.CreateRequest(joinOrganizationRequest);

                return this.RedirectToAction("Index", "Home");
            }

            return this.View("Index", model);
        }
    }
}