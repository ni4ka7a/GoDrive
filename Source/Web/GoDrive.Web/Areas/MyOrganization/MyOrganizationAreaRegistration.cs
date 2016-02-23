namespace GoDrive.Web.Areas.MyOrganization
{
    using System.Web.Mvc;

    public class MyOrganizationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MyOrganization";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MyOrganization_default",
                "MyOrganization/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "GoDrive.Web.Areas.MyOrganization.Controllers" });
        }
    }
}
