namespace GoDrive.Web.Controllers.Tests
{
    using Common.Tests.Fakes;
    using Infrastructure.Mapping;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TestStack.FluentMVCTesting;
    using ViewModels.JoinOrganization;

    [TestClass]
    public class JoinOrganizationControllerTests
    {
        private JoinOrganizationController joinOrganizationController;

        [TestInitialize]
        public void Setup()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(OrganizationsController).Assembly);

            this.joinOrganizationController = new JoinOrganizationController(
                new FakeOrganizationsService(),
                new FakeJoinOrganizationService());
        }

        [TestMethod]
        public void IndexActionShouldReturnCorrectResult()
        {
            this.joinOrganizationController.WithCallTo(x => x.Index(1))
                .ShouldRenderView("Index")
                .WithModel<JoinOrganizationViewModel>(
                 viewModel =>
                 {
                     Assert.AreEqual(17, viewModel.Age);
                     Assert.AreEqual(1, viewModel.OrganizationId);
                     Assert.AreEqual("name 0", viewModel.OrganizationName);
                 })
                .AndNoModelErrors();
        }
    }
}
