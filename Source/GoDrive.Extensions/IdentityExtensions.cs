namespace GoDrive.Extensions
{
    using System.Security.Claims;
    using System.Security.Principal;

    public static class IdentityExtensions
    {
        public static string GetOrganizationId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("OrganizationId");

            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
