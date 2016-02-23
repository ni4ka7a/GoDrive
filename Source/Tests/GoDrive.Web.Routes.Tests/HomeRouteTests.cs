namespace GoDrive.Web.Routes.Tests
{
    using System.Web.Routing;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcRouteTester;

    [TestClass]
    public class HomeRouteTests
    {
        [TestMethod]
        public void HomeRounteShouldMapCorrectly()
        {
            const string Url = "/";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url).To<HomeController>(c => c.Index());
        }

        [TestMethod]
        public void AboutRounteShouldMapCorrectly()
        {
            const string Url = "/Home/About";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url).To<HomeController>(c => c.About());
        }
    }
}
