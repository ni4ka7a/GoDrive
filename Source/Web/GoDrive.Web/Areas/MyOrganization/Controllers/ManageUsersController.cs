namespace GoDrive.Web.Areas.MyOrganization.Controllers
{
    using System.Web.Mvc;
    using Services.Data.Contracts;

    public class ManageUsersController : Controller
    {
        private IUsersService users;

        public ManageUsersController(IUsersService users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}