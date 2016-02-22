namespace GoDrive.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.JoinedOrganization;

    [Authorize]
    public class JoinedOrganizationController : BaseController
    {
        private IDriveEventsService driveEvents;
        private IUsersService users;

        public JoinedOrganizationController(IUsersService users, IDriveEventsService driveEvents)
        {
            this.driveEvents = driveEvents;
            this.users = users;
        }


        public ActionResult Index()
        {
            var currentUserId = this.User.Identity.GetUserId();

            var userHaveJoinedOrganization = this.users
                .GetAll()
                .Where(u => u.Id == currentUserId)
                .Any(u => u.JoinedOrganizationId != null);

            if (!userHaveJoinedOrganization)
            {
                return this.View();
            }

            var organization = this.users
                .GetAll()
                .Where(u => u.Id == currentUserId)
                .Select(x => x.JoinedOrganization)
                .To<JoinedOrganizationViewModel>()
                .FirstOrDefault();

            return this.View(organization);
        }

        public ActionResult MyScheduler()
        {
            return this.View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var userId = this.User.Identity.GetUserId();
            return this.Json(
                this.driveEvents
                .GetEventsByUser(userId)
                .To<DriveEventViewModel>()
                .ToDataSourceResult(request));
        }

        public ActionResult MyProgress()
        {
            return this.View();
        }
    }
}