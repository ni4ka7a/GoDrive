namespace GoDrive.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.OrganizationRequests;
    using Web.Controllers;
    using ViewModels.Organizations;
    public class ManageRequestsController : BaseController
    {
        private ICreateOrganizationRequestsService createOrganizationRequests;

        public ManageRequestsController(ICreateOrganizationRequestsService createOrganizationRequests)
        {
            this.createOrganizationRequests = createOrganizationRequests;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult GetUnProceedRequest()
        {
            var requests = this.createOrganizationRequests
                .GetUnProceededRequests()
                .To<CreateOrganizationRequestViewModel>()
                .ToList();

            return this.PartialView("_OrganizationsRequestsPartial", requests);
        }

        public ActionResult GetProceedRequest()
        {
            var requests = this.createOrganizationRequests
                .GetProceededRequests()
                .To<CreateOrganizationRequestViewModel>()
                .ToList();

            return this.PartialView("_OrganizationsRequestsPartial", requests);
        }
    }
}