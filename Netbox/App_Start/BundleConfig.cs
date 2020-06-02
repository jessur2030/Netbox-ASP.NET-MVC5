using System.Web;
using System.Web.Optimization;

namespace Netbox
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                            "~/Scripts/jquery-{version}.js",
                            //"~/scripts/popper.js",
                            "~/Scripts/bootstrap.js",
                            "~/Scripts/bootbox.js",
                         "~/Scripts/DataTables/jquery.dataTables.js",
                         "~/Scripts/DataTables/DataTables.boostrap4.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
           
            //         ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/datatables/css/datatables.bootstrap4.css",
                      //"~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
