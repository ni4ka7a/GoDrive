﻿namespace GoDrive.Web
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery.unobtrusive-ajax.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/materialize").Include("~/Scripts/materialize.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/progressBar").Include("~/Scripts/progressbar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                      "~/Scripts/KendoUI/kendo.all.min.js",
                      "~/Scripts/KendoUI/kendo.timezones.min.js",
                      "~/Scripts/KendoUI/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/imageGallery").Include("~/Scripts/app/imageGalleryInitialize.js"));
            bundles.Add(new ScriptBundle("~/bundles/progressBarInitialize").Include("~/Scripts/app/progressBarInitialize.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/materialize.min.css", "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                     "~/Content/KendoUI/kendo.bootstrap.min.css",
                     "~/Content/KendoUI/kendo.common.min.css",
                     "~/Content/KendoUI/kendo.common-bootstrap.min.css",
                     "~/Content/KendoUI/kendo.default.min.css"));
        }
    }
}
