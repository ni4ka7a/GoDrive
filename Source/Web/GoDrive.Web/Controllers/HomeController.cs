﻿namespace GoDrive.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Home;
    using ViewModels.Organizations;

    public class HomeController : BaseController
    {
        private IOrganizationsService organizations;

        public HomeController(IOrganizationsService organizations)
        {
            this.organizations = organizations;
        }

        public ActionResult Index()
        {
            var topOrganizations = this.Cache.Get(
                "topOrganizations",
                () => this.organizations
                .GetTopOrganizations(GlobalConstants.TopOrganizationsCount)
                .To<OrganizationViewModel>()
                .ToList(),
                30 * 60);

            var model = new IndexViewModel()
            {
                Organizations = topOrganizations
            };

            return this.View(model);
        }

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            return this.View();
        }
    }
}
