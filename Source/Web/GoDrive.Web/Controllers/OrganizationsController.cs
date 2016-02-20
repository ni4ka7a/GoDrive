namespace GoDrive.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Organizations;

    public class OrganizationsController : Controller
    {
        private IOrganizationsService organizations;

        public OrganizationsController(IOrganizationsService organizations)
        {
            this.organizations = organizations;
        }

        public ActionResult Index(int page = 1)
        {
            if (page < 1)
            {
                page = 1;
            }

            var allOrganizationsCount = this.organizations.GetALl().Count();
            var totalPages = (int)Math.Ceiling(allOrganizationsCount / (decimal) GlobalConstants.OrganizationsPerPage);
            var organizationsToSkip = (page - 1) * GlobalConstants.OrganizationsPerPage;

            var organizations = this.organizations
                .GetALl()
                .OrderBy(o => o.Students.Count())
                .Skip(organizationsToSkip)
                .Take(GlobalConstants.OrganizationsPerPage)
                .To<OrganizationViewModel>()
                .ToList();

            var organizationListModel = new OrganizationListViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Organizations = organizations
            };

            return this.View(organizationListModel);
        }
    }
}