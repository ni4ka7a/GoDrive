namespace GoDrive.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Infrastructure.Mapping;
    using ViewModels.JoinedOrganization;
    [Authorize]
    public class JoindedOrganizationController : BaseController
    {
        private IOrganizationsService organizations;
        private IUsersService users;

        public JoindedOrganizationController(IUsersService users)
        {
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
    }
}