namespace GoDrive.Web.Areas.MyOrganization.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Filters;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels;
    using Web.Controllers;

    [AutorizeOrganizationOwnerAttribute]
    public class SchedulerController : BaseController
    {
        private IDriveEventsService driveEvents;
        private IUsersService users;

        public SchedulerController(IDriveEventsService driveEvents, IUsersService users)
        {
            this.driveEvents = driveEvents;
            this.users = users;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var userId = this.User.Identity.GetUserId();
            return this.Json(
                this.driveEvents
                .GetEventsByOrganization(userId)
                .To<DriveEventViewModel>()
                .ToDataSourceResult(request));
        }

        public virtual JsonResult Create([DataSourceRequest] DataSourceRequest request, DriveEventViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var currentUserId = this.User.Identity.GetUserId();
                var driveEvent = this.Mapper.Map<DriveEvent>(model);

                this.driveEvents.Create(driveEvent, currentUserId);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        public virtual JsonResult Update([DataSourceRequest] DataSourceRequest request, DriveEventViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var driveEvent = this.Mapper.Map<DriveEvent>(model);
                this.driveEvents.Update(driveEvent);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        public virtual JsonResult Destroy([DataSourceRequest] DataSourceRequest request, DriveEventViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.driveEvents.Delete(model.Id);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        public virtual JsonResult Read_Users([DataSourceRequest] DataSourceRequest request)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var organizationUsers = this.users
                .GetUsersForOrganization(currentUserId)
                .Select(u => new
                {
                    Text = u.UserName,
                    Value = u.Id,
                    Color = "#311b92"
                });

            return this.Json(organizationUsers.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}