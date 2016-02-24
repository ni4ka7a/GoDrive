namespace GoDrive.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : BaseController
    {
        public ActionResult CannotJoinOrganization()
        {
            return this.View();
        }

        public ActionResult NotFound()
        {
            return this.View();
        }
    }
}
