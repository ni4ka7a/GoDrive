namespace GoDrive.Web.Areas.MyOrganization.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using Web.Controllers;
    using ViewModels;
    using Infrastructure.Mapping;
    public class ManageCarImagesController : BaseController
    {
        // TODO: replace this with carsImagesService
        private IOrganizationImagesService organizationImages;
        private IOrganizationsService organizations;
        private ICarImagesService carImages;

        public ManageCarImagesController(
            IOrganizationsService organizations,
            IOrganizationImagesService organizationImages,
            ICarImagesService carImages)
        {
            this.organizations = organizations;
            this.organizationImages = organizationImages;
            this.carImages = carImages;
        }

        public ActionResult Index()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var organizationId = this.organizations
                .GetALl()
                .Where(o => o.UserId == currentUserId)
                .Select(o => o.Id)
                .FirstOrDefault();

            var carImages = this.carImages
                .GetImagesForOrganization(organizationId)
                .To<CarImageViewModel>()
                .ToList();

            return this.View(carImages);
        }

        public ActionResult DeleteCarImage(int id)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var organizationId = this.organizations
                .GetALl()
                .Where(o => o.UserId == currentUserId)
                .Select(o => o.Id)
                .FirstOrDefault();

            this.carImages.Delete(id, organizationId);

            return this.RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public ActionResult UploadCarImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                var extension = file.FileName.Substring(file.FileName.LastIndexOf("."));

                if (!this.organizationImages.ValidateFileExtention(extension))
                {
                    this.TempData["error"] = $"The Image Should be {GlobalConstants.JpgFileExtension} or {GlobalConstants.PngFileExtension}.";
                    return this.RedirectToAction("Index");
                }

                var currentUserId = this.User.Identity.GetUserId();
                var organization = this.organizations
                    .GetALl()
                    .Where(o => o.UserId == currentUserId)
                    .FirstOrDefault();

                var imageName = Guid.NewGuid();
                var savePath = $"/Images/{organization.Name}/{imageName}{extension}";
                var saveDirPathMapped = System.IO.Path.GetDirectoryName(this.Server.MapPath(savePath));
                if (!System.IO.Directory.Exists(saveDirPathMapped))
                {
                    System.IO.Directory.CreateDirectory(saveDirPathMapped);
                }

                file.SaveAs(this.Server.MapPath(savePath));

                var image = new CarImage()
                {
                    Name = imageName.ToString(),
                    Url = savePath,
                    Organization = organization
                };

                this.carImages.Add(image);
            }

            return this.RedirectToAction("Index");
        }
    }
}