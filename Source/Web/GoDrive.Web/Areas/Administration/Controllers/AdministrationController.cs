namespace GoDrive.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Data.Models;
    using GoDrive.Common;
    using GoDrive.Web.Controllers;
    using Services.Data.Contracts;
    using ViewModels.Organizations;
    using System.Linq;
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
        private IOrganizationsService organizations;
        private IUsersService users;

        public AdministrationController(IOrganizationsService organizations, IUsersService users)
        {
            this.organizations = organizations;
            this.users = users;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult CreateOrganization()
        {
            this.BindUsers();
            return this.View();
        }

        [HttpPost]
        public ActionResult CreateOrganization(CreateOganizationViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.BindUsers();
                return this.View(model);
            }

            var organizationToCreate = this.Mapper.Map<Organization>(model);
            this.organizations.Create(organizationToCreate);

            return this.RedirectToAction<AdministrationController>(c => c.Index());
        }

        private void BindUsers()
        {
            var usersList = this.users
                .GetAll()
                .Select(u => new SelectListItem()
                {
                    Text = u.UserName,
                    Value = u.Id
                })
                .ToList();

            this.ViewData["users"] = usersList;
        }
    }
}
