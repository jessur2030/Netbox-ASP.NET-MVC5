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
                            //"~/Scripts/jquery-3.5.1.js",

                            "~/Scripts/bootstrap.js",
                            "~/Scripts/bootbox.js",
                         //"~/Scripts/buttons.bootstrap4.js",
                         //"~/Scripts/DataTables/responsive.bootstrap4.min.js",
                         "~/Scripts/DataTables/jquery.dataTables.js",
                         "~/Scripts/DataTables/DataTables.bootstrap4.js",
                         "~/Scripts/typeahead.bundle.js",
                         "~/Scripts/toastr.js"

                       ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

       


            bundles.Add(new StyleBundle("~/Content/css").Include(
                        //"~/Content/bootstrap-lumen.css",
                      "~/Content/bootstrap.css",
                      "~/Content/datatables/css/dataTables.bootstrap4.css",
                      //"~/Content/datatables/css/responsive.bootstrap4.css",



                      //"~/Content/datatables/css/buttons.bootstrap4.css",
                      //"~/Content/datatables/css/jquery.dataTables.css",

                      "~/Content/typeahead.css",
                      "~/Content/site.css",
                      "~/Content/toastr.css",
                      "~/Content/App.css"));

            //bundles.Add(new StyleBundle("~/bundles/table").Include(
            //          "~/Content/DataTables/css/dataTables-{version}.css"

            //     ));
        }
    }
}
