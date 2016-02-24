namespace GoDrive.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using Organizations;

    public class IndexViewModel
    {
        public IEnumerable<OrganizationViewModel> Organizations { get; set; }

        public int UsersCount { get; set; }

        public int OrganizationsCount { get; set; }
    }
}
