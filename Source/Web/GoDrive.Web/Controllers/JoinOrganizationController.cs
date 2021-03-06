﻿namespace GoDrive.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
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

        public ActionResult Index(int id = 0)
        {
            var userId = this.User.Identity.GetUserId();

            if (!this.joinOrganizationRequests.CannotJoinOrganization(userId))
            {
                return this.RedirectToAction("CannotJoinOrganization", "Error");
            }

            var organization = this.organizations
                .GetById(id)
                .FirstOrDefault();

            if (organization == null)
            {
                return this.RedirectToAction("NotFound", "Error");
            }

            var organizationModel = new JoinOrganizationViewModel()
            {
                OrganizationId = organization.Id,
                OrganizationName = organization.Name,
                Age = 17
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
