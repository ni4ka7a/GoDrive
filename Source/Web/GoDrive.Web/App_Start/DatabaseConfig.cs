namespace GoDrive.Web.App_Start
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            ApplicationDbContext.Create().Database.Initialize(true);
        }
    }
}