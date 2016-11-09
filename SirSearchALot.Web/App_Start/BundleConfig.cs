﻿using System.Web;
using System.Web.Optimization;

namespace SirSearchALot.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/jquery-ui").Include("~/Scripts/jquery-ui-1.9.2.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/jqueryUploader").Include("~/Scripts/jquery.fileupload.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/jqueryUploaderIframe").Include("~/Scripts/jquery.iframe-transport.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockoutViewmodels").Include(
                    "~/Scripts/knockout-3.4.0.js",
                    "~/ViewModels/PersonViewModel.js",
                    "~/ViewModels/SirSearchALotViewModel.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery.fileupload-ui-noscript.css",
                      "~/Content/jquery.fileupload-ui.css"));
        }
    }
}
