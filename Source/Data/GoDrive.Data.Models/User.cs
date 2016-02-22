namespace GoDrive.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IDeletableEntity, IAuditInfo
    {
        private ICollection<DriveEvent> driveEvents;

        public User()
        {
            this.driveEvents = new HashSet<DriveEvent>();
        }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        // [Range(16, 130)]
        public int Age { get; set; }

        public int? OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public bool IsInOrganization { get; set; }

        public int? JoinedOrganizationId { get; set; }

        public virtual Organization JoinedOrganization { get; set; }

        public virtual ICollection<DriveEvent> DriveEvents
        {
            get { return this.driveEvents; }
            set { this.driveEvents = value; }
        }

        // IAuditInfo and IDeletableEntity properties
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
