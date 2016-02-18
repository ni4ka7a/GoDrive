namespace GoDrive.Web.ViewModels.Organizations
{
    using System.Collections.Generic;

    public class OrganizationListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<OrganizationViewModel> Organizations { get; set; }
    }
}