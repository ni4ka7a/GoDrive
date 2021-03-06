﻿namespace GoDrive.Web.Controllers
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

            var allOrganizationsCount = this.organizations.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allOrganizationsCount / (decimal)GlobalConstants.OrganizationsPerPage);
            var organizationsToSkip = (page - 1) * GlobalConstants.OrganizationsPerPage;

            var organizations = this.organizations
                .GetAll()
                .OrderByDescending(o => o.CreatedOn)
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

        public ActionResult Details(int id = 0)
        {
            var model = this.organizations
                .GetAll()
                .Where(x => x.Id == id)
                .To<OrganizationDetailsViewModel>()
                .FirstOrDefault();

            if (model == null)
            {
                return this.RedirectToAction("NotFound", "Error");
            }

            return this.View(model);
        }
    }
}
