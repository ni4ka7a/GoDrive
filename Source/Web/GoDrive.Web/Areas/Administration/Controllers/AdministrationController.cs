namespace GoDrive.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Data.Models;
    using GoDrive.Common;
    using GoDrive.Web.Controllers;
    using Services.Data.Contracts;
    using ViewModels.Organizations;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
        private IOrganizationsService organizations;
        private IUsersService users;
        private IOrganizationImagesService organizationImages;

        public AdministrationController(
            IOrganizationsService organizations,
            IUsersService users,
            IOrganizationImagesService organizationImages)
        {
            this.organizations = organizations;
            this.users = users;
            this.organizationImages = organizationImages;
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
            var isCreated = this.organizations.Create(organizationToCreate);

            if (!isCreated)
            {
                this.ModelState.AddModelError(string.Empty, GlobalConstants.UserAlreadyHaveOrganizationErrorMessage);
                this.BindUsers();
                return this.View(model);
            }

            //var owner = this.users
            //    .GetAll()
            //    .Where(u => u.Id == model.UserId)
            //    .FirstOrDefault();

            //if (owner.OrganizationId != null)
            //{
            //    this.ModelState.AddModelError(string.Empty, GlobalConstants.UserAlreadyHaveOrganizationErrorMessage);
            //    this.BindUsers();
            //    return this.View(model);
            //}

            //var defaultImage = this.organizationImages.GetDefaultImage();
            //var organizationToCreate = this.Mapper.Map<Organization>(model);
            //organizationToCreate.OrganizationImage = defaultImage;

            //this.users.AddOrganization(organizationToCreate.UserId, organizationToCreate);

            return this.RedirectToAction<AdministrationController>(c => c.Index());
        }

        private void BindUsers()
        {
            var usersList = this.users
                .GetAll()
                .Where(u => u.OrganizationId == null)
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
