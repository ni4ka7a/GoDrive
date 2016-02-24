namespace GoDrive.Web.Areas.MyOrganization.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Filters;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels;

    [AutorizeOrganizationOwnerAttribute]
    public class ManageUsersController : Controller
    {
        private IUsersService users;

        public ManageUsersController(IUsersService users, IDriveEventsService driveEvents)
        {
            this.users = users;
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
    }
}
