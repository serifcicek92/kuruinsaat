using System.Web;
using System.Web.Optimization;

namespace kuruinsaat
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = true;
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/vendor/jquery-1.12.4.min.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            // "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/vendor/modernizr-3.5.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css", 
                      "~/Content/owl.carousel.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/magnific-popup.css",
                      "~/Content/themify-icons.css",
                      "~/Content/gijgo.css",
                      "~/Content/nice-select.css",
                      "~/Content/flaticon.css",
                      "~/Content/slicknav.css",
                      "~/Content/theme-default.css",
                      "~/Content/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/javascripts").Include(
                      "~/Scripts/vendor/modernizr-3.5.0.min.js",
                      "~/Scripts/popper.min.js",
                      "~/Scripts/owl.carousel.min.js",
                      "~/Scripts/isotope.pkgd.min.js",
                      "~/Scripts/ajax-form.js",
                      "~/Scripts/waypoints.min.js",
                      "~/Scripts/jquery.counterup.min.js",
                      "~/Scripts/imagesloaded.pkgd.min.js",
                      "~/Scripts/scrollIt.js",
                      "~/Scripts/jquery.scrollUp.min.js",
                      "~/Scripts/wow.min.js",
                      "~/Scripts/gijgo.min.js",
                      "~/Scripts/nice-select.min.js",
                      "~/Scripts/jquery.slicknav.min.js",
                      "~/Scripts/plugins.js",
                      "~/Scripts/jquery.magnific-popup.min.js",
                      "~/Scripts/contact.js",
                      "~/Scripts/jquery.ajaxchimp.min.js",
                      "~/Scripts/jquery.form.js",
                      "~/Scripts/jquery.validate.min.js",
                      "~/Scripts/mail-script.js",
                      "~/Scripts/main.js"));
        }
    }
}
