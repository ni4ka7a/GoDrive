namespace GoDrive.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using GoDrive.Common;
    using GoDrive.Web.Controllers;
    using ViewModels.Organizations;
    using System.Collections.Generic;
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
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

            // TODO: Create the organization
            return this.RedirectToAction<AdministrationController>(c => c.Index());
        }

        private void BindUsers()
        {
            var usersList = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "pesho", Value = "1" },
                new SelectListItem() { Text = "Gosho", Value = "1" },
                new SelectListItem() { Text = "IIvan", Value = "1" },
                new SelectListItem() { Text = "sta", Value = "1" },
                new SelectListItem() { Text = "daw", Value = "1" },
                new SelectListItem() { Text = "daw", Value = "1" },
                new SelectListItem() { Text = "daw", Value = "1" },
                new SelectListItem() { Text = "daw", Value = "1" }
            };

            this.ViewData["users"] = usersList;
        }
    }
}
