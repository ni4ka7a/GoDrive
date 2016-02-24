namespace GoDrive.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.OrganizationRequests;
    using Web.Controllers;

    public class ManageRequestsController : BaseController
    {
        private ICreateOrganizationRequestsService createOrganizationRequests;
        private IOrganizationsService organizations;

        public ManageRequestsController(
            ICreateOrganizationRequestsService createOrganizationRequests,
            IOrganizationsService organizations)
        {
            this.createOrganizationRequests = createOrganizationRequests;
            this.organizations = organizations;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult CreateOrganization(CreateOrganizationRequestViewModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                this.TempData[GlobalConstants.TempDataErrorKey] = GlobalConstants.InvalidOrganizationRequestErrorMessage;
                return this.RedirectToAction(x => x.Index());
            }

            var organizationToCreate = new Organization()
            {
                Name = model.OrganizationName,
                AboutInfo = model.OrganizationDescription,
                UserId = model.UserId,
                PhoneNumber = model.PhoneNumber
            };

            var isCreated = this.organizations.Create(organizationToCreate);

            if (!isCreated)
            {
                this.TempData[GlobalConstants.TempDataErrorKey] = GlobalConstants.InvalidOrganizationRequestErrorMessage;
                return this.RedirectToAction(x => x.Index());
            }

            this.TempData[GlobalConstants.TempDataSuccessKey] = GlobalConstants.CreatedOrganizationSuccessMessage;

            this.createOrganizationRequests.ProceedRequest(model.Id);
            return this.RedirectToAction(x => x.Index());
        }

        public ActionResult GetUnProceedRequest()
        {
            var requests = this.createOrganizationRequests
                .GetUnProceededRequests()
                .To<CreateOrganizationRequestViewModel>()
                .ToList();

            return this.PartialView(GlobalConstants.OrganizationRequestsPratialViewName, requests);
        }

        public ActionResult GetProceedRequest()
        {
            var requests = this.createOrganizationRequests
                .GetProceededRequests()
                .To<CreateOrganizationRequestViewModel>()
                .ToList();

            return this.PartialView(GlobalConstants.OrganizationRequestsPratialViewName, requests);
        }

        public ActionResult ProceedRequest(int id)
        {
            this.createOrganizationRequests.ProceedRequest(id);
            return this.RedirectToAction(x => x.Index());
        }
    }
}
