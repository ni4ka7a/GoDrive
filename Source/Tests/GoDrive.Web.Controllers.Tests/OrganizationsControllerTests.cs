namespace GoDrive.Web.Controllers.Tests
{
    using System.Linq;
    using Common.Tests.Fakes;
    using Infrastructure.Mapping;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestStack.FluentMVCTesting;
    using ViewModels.Organizations;

    [TestClass]
    public class OrganizationsControllerTests
    {
        private OrganizationsController organizationsController;

        [TestInitialize]
        public void Setup()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(OrganizationsController).Assembly);

            this.organizationsController = new OrganizationsController(new FakeOrganizationsService());
        }

        [TestMethod]
        public void OrganizationsControllerShoulRenderCorrectlyTheIndexPage()
        {

            this.organizationsController.WithCallTo(x => x.Index(1))
                .ShouldRenderView("Index")
                .WithModel<OrganizationListViewModel>(
                 viewModel =>
                 {
                     Assert.AreEqual(5, viewModel.Organizations.Count());
                 })
                .AndNoModelErrors();
        }

        [TestMethod]
        public void OrganizationsControllerShoulRenderZeroResultsOnTheSecondPage()
        {
            this.organizationsController.WithCallTo(x => x.Index(2))
                .ShouldRenderView("Index")
                .WithModel<OrganizationListViewModel>(
                 viewModel =>
                 {
                     Assert.AreEqual(0, viewModel.Organizations.Count());
                 })
                .AndNoModelErrors();
        }

        [TestMethod]
        public void ShouldRenderCorrectResultsOnTheDetailsPage()
        {
            this.organizationsController.WithCallTo(x => x.Details(1))
                .ShouldRenderView("Details")
                .WithModel<OrganizationDetailsViewModel>(
                 viewModel =>
                 {
                     Assert.AreEqual(1, viewModel.Id);
                     Assert.AreEqual("info 0", viewModel.AboutInfo);
                 })
                .AndNoModelErrors();
        }

        [TestMethod]
        public void ShouldRedirectToNotFoundIfOrganizationIsNotFound()
        {
            this.organizationsController.WithCallTo(x => x.Details(300))
                .ShouldRedirectToRoute(string.Empty);
        }
    }
}
