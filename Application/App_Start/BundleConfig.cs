using System.Web;
using System.Web.Optimization;

namespace Application
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));




            bundles.Add(new ScriptBundle("~/bundles/Register").Include(
                      "~/Scripts/Register.js"));

            bundles.Add(new ScriptBundle("~/bundles/JqueryPackage").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/jquery-1.10.2.min.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/Validation").Include(
                      "~/Scripts/jquery.validate.min.js",
                      "~/Scripts/jquery.validate.unobtrusive.min.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/FarmerDetail").Include(
                      "~/Scripts/FarmerDetail.js",
                      "~/Scripts/OAcommon.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/FAdetail").Include(
                      "~/Scripts/FAdetail.js",
                      "~/Scripts/OAcommon.js"
                      ));
            bundles.Add(new ScriptBundle("~/Content/BootstrapPackage").Include(
                           "~/Content/bootstrap.min.css"
                           ));

            bundles.Add(new StyleBundle("~/Content/ComonOAcss").Include(
                     "~/Content/ComonOAcss.css"));
           
            bundles.Add(new ScriptBundle("~/bundles/PocektDetail").Include(
                      "~/Scripts/PocketDetail.js",
                      "~/Scripts/OAcommon.js"
                      ));
        }
    }
}
