namespace GoDrive.Web.Areas.MyOrganization.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels;

    public class ManageUsersController : Controller
    {
        private IUsersService users;
        private IDriveEventsService driveEvents;

        public ManageUsersController(IUsersService users, IDriveEventsService driveEvents)
        {
            this.users = users;
            this.driveEvents = driveEvents;
        }

        public ActionResult Index()
        {
            var currentUserId = this.User.Identity.GetUserId();

            var users = this.users
                .GetUsersForOrganization(currentUserId)
                .To<ManageUserViewModel>()
                .ToList();

            return this.View(users);
        }

        public ActionResult Scheduler()
        {
            return this.View();
        }

        public virtual JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {

            return this.Json(this.driveEvents
                .GetAll()
                .To<DriveEventViewModel>()
                .ToDataSourceResult(request));
        }
    }
}