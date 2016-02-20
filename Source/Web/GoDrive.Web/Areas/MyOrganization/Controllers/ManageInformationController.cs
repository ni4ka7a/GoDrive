namespace GoDrive.Web.Areas.MyOrganization.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Data.Models;
    using Filters;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels;

    [AutorizeOrganizationOwnerAttribute]
    public class ManageInformationController : Controller
    {
        private IOrganizationsService organizations;

        public ManageInformationController(IOrganizationsService organizations)
        {
            this.organizations = organizations;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var currentUserId = this.User.Identity.GetUserId();

            var organization = this.organizations
                .GetALl()
                .Where(o => o.UserId == currentUserId)
                .To<OrganizationInformationViewModel>()
                .FirstOrDefault();

            return this.View(organization);
        }

        public ActionResult UpdateOrganization(OrganizationInformationViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var organization = new Organization()
                {
                    Id = model.Id,
                    AboutInfo = model.AboutInfo,
                    Name = model.Name
                };

                this.organizations.Update(organization);
                return this.RedirectToAction(x => x.Index());
            }

            return this.View("Index", model);
        }
    }
}