namespace GoDrive.Web.Areas.MyOrganization.Controllers
{
    using System.Web.Mvc;
    using Filters;

    [AutorizeOrganizationOwnerAttribute]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}