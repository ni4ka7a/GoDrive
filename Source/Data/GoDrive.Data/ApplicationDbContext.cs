namespace GoDrive.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;
    using GoDrive.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<CreateOrganizationRequest> CreateOrganizationRequests { get; set; }

        public virtual IDbSet<JoinOrganizationRequest> JoinOrganizationRequests { get; set; }

        public virtual IDbSet<OrganizationImage> OrganizationImages { get; set; }

        public virtual IDbSet<CarImage> CarsImages { get; set; }

        public virtual IDbSet<Organization> Organizations { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
