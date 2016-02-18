﻿namespace GoDrive.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using GoDrive.Common;
    using GoDrive.Data.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName, CreatedOn = DateTime.Now};
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }

            this.SeedOrganizations(context);
        }

        private void SeedOrganizations(ApplicationDbContext context)
        {
            if (!context.Organizations.Any())
            {
                var owner = context.Users.FirstOrDefault();

                for (int i = 0; i < 5; i++)
                {
                    var organization = new Organization()
                    {
                        Name = $"Org {i}",
                        AboutInfo = $"some info {i}",
                        User = owner
                    };

                    context.Organizations.Add(organization);
                }

                context.SaveChanges();
            }
        }
    }
}