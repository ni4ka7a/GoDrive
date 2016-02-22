namespace GoDrive.Web.Areas.MyOrganization.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Filters;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using ViewModels;
    using Web.Controllers;
    using Microsoft.AspNet.Identity;
    using Data.Models;
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
            return this.Json(
                this.driveEvents
                .GetAll()
                .To<DriveEventViewModel>()
                .ToDataSourceResult(request));
        }

        public virtual JsonResult Create([DataSourceRequest] DataSourceRequest request, DriveEventViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var driveEvent = this.Mapper.Map<DriveEvent>(model);

                this.driveEvents.Create(driveEvent);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request,this. ModelState));
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
                    Color = "#f8a398"
                });

            return this.Json(organizationUsers.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}