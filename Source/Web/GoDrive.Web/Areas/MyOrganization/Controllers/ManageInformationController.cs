namespace GoDrive.Web.Areas.MyOrganization.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Common;
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
        private IOrganizationImagesService organizationImages;

        public ManageInformationController(IOrganizationsService organizations, IOrganizationImagesService organizationImages)
        {
            this.organizations = organizations;
            this.organizationImages = organizationImages;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var currentUserId = this.User.Identity.GetUserId();

            var organization = this.organizations
                .GetAll()
                .Where(o => o.UserId == currentUserId)
                .To<OrganizationInformationViewModel>()
                .FirstOrDefault();

            return this.View(organization);
        }

        public ActionResult UpdateOrganization(OrganizationInformationViewModel model, HttpPostedFileBase file)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var organization = new Organization()
                {
                    Id = model.Id,
                    AboutInfo = model.AboutInfo,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber
                };

                // TODO: Extract this logic somewhere
                if (file != null)
                {
                    var extension = file.FileName.Substring(file.FileName.LastIndexOf("."));

                    if (!this.organizationImages.ValidateFileExtention(extension))
                    {
                        this.ModelState.AddModelError(string.Empty, $"The Image Should be {GlobalConstants.JpgFileExtension} or {GlobalConstants.PngFileExtension}.");
                        return this.View("Index", model);
                    }

                    var imageName = Guid.NewGuid();
                    var savePath = $"/Images/{organization.Name}/{imageName}{extension}";
                    var saveDirPathMapped = System.IO.Path.GetDirectoryName(this.Server.MapPath(savePath));
                    if (!System.IO.Directory.Exists(saveDirPathMapped))
                    {
                        System.IO.Directory.CreateDirectory(saveDirPathMapped);
                    }

                    file.SaveAs(this.Server.MapPath(savePath));

                    var image = new OrganizationImage()
                    {
                        Name = imageName.ToString(),
                        Url = savePath
                    };

                    organization.OrganizationImage = image;
                }

                this.organizations.Update(organization);
                return this.RedirectToAction(x => x.Index());
            }

            return this.View("Index", model);
        }
    }
}
