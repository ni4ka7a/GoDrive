﻿namespace GoDrive.Web.Areas.MyOrganization.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Common;
    using Extensions;
    using Filters;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels;
    using Web.Controllers;

    [AutorizeOrganizationOwnerAttribute]
    public class ManageRequestsController : BaseController
    {
        private IJoinOrganizationService joinOrganizationRequests;
        private IUsersService users;
        private IOrganizationsService organizations;

        public ManageRequestsController(
            IJoinOrganizationService joinOrganizationRequests,
            IUsersService users,
            IOrganizationsService organizations)
        {
            this.joinOrganizationRequests = joinOrganizationRequests;
            this.users = users;
            this.organizations = organizations;
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

            return this.PartialView(GlobalConstants.UserRequestsPratialName, requests);
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

        public ActionResult AddToOrganization(string userId, int requestId)
        {
            var organizationOwnerId = this.User.Identity.GetUserId();
            var organizationIdString = this.User.Identity.GetOrganizationId();

            var userAddedSuccessfully = this.organizations.AddUser(userId, organizationIdString);

            if (!userAddedSuccessfully)
            {
                this.TempData[GlobalConstants.TempDataErrorKey] = GlobalConstants.UserCannotJoinOrganizationErrorMessage;
            }

            this.joinOrganizationRequests.ProceedUserRequest(requestId);

            return this.RedirectToAction(x => x.Index());
        }

        public ActionResult RejectToOrganization(int id)
        {
            this.joinOrganizationRequests.ProceedUserRequest(id);

            return this.RedirectToAction(x => x.Index());
        }
    }
}
