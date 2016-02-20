namespace GoDrive.Web.Filters
{
    using System.Web;
    using System.Web.Mvc;
    using Data.Common;
    using Data.Models;
    using Microsoft.AspNet.Identity;

    public class AutorizeOrganizationOwnerAttribute : AuthorizeAttribute
    {
        public IDbRepository<User> DbUsers { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            var userId = httpContext.User.Identity.GetUserId();
            var organizationId = this.DbUsers.GetById(userId).OrganizationId;

            if (organizationId == null)
            {
                return false;
            }

            return true;
        }
    }
}