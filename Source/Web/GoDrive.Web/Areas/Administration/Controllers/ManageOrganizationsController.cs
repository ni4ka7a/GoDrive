namespace GoDrive.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using ViewModels.Organizations;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ManageOrganizationsController : BaseController
    {
        private IOrganizationsService organizations;

        public ManageOrganizationsController(IOrganizationsService organizations)
        {
            this.organizations = organizations;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Organizations_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.organizations
                .GetAllWithDeleted()
                .To<OrganizationGridViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Organizations_Update([DataSourceRequest]DataSourceRequest request, OrganizationGridInputMdel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var organizationToUpdate = this.Mapper.Map<Organization>(model);
                this.organizations.Update(organizationToUpdate);
            }

            var organizationToDispley = this.organizations
                .GetById(model.Id)
                .To<OrganizationGridViewModel>()
                .FirstOrDefault();

            return this.Json(new[] { organizationToDispley }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Organizations_Destroy([DataSourceRequest]DataSourceRequest request, OrganizationGridInputMdel organizationToDelete)
        {
            this.organizations.Delete(organizationToDelete.Id);

            return this.Json(new[] { organizationToDelete }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
