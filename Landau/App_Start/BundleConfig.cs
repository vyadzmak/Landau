using System.Web;
using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace Landau
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
//        public static void RegisterBundles(BundleCollection bundles)
//        {
//            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
//                        "~/Scripts/jquery-{version}.js"));

//            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
//                        "~/Scripts/jquery.validate*"));

//            // Use the development version of Modernizr to develop with and learn from. Then, when you're
//            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
//            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
//                        "~/Scripts/modernizr-*"));

//            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
//                      "~/Scripts/bootstrap.js",
//                      "~/Scripts/respond.js"));

//            bundles.Add(new StyleBundle("~/Content/css").Include(
//                      "~/Content/bootstrap.css",
//                      "~/Content/site.css"));
//            bundles.Add(new ScriptBundle("~/bundles/sheets").Include(
//                    "~/sheetUI3.2/js/extjs4.2.1/ext-all.js",
//                      "~/sheetUI3.2/js/extjs4.2.1/locale/ext-lang-en.js",
//                      "~/sheetUI3.2/js/EnterpriseSheet/src/language/en.js",
//                      "~/sheetUI3.2/js/src/EnterpriseSheet/Config.js",
//                      "~/sheetUI3.2/js/src/EnterpriseSheet/enterprisesheet.js",
//                      "~/sheetUI3.2/js/EnterpriseSheet/src/EnterpriseSheet/api/SheetAPI.js",
//                      "~/Scripts/MoveTable/bootstrap-table.js",
//                      "~/Scripts/User/TransactionsWidget.js"
//                      ));
//            //bundles.Add(new StyleBundle("~/Content/styles").Include(
//            //      "~/startbootstrap-sb-admin-2-1.0.7/bower_components/bootstrap/dist/css/bootstrap.min.css",
//            //        "~/startbootstrap-sb-admin-2-1.0.7/bower_components/metisMenu/dist/metisMenu.min.css",
//            //        "~/startbootstrap-sb-admin-2-1.0.7/dist/css/timeline.css",
//            //        "~/startbootstrap-sb-admin-2-1.0.7/dist/css/sb-admin-2.css",
//            //       "~/startbootstrap-sb-admin-2-1.0.7/bower_components/morrisjs/morris.css",
//            //       " ~/startbootstrap-sb-admin-2-1.0.7/bower_components/font-awesome/css/font-awesome.min.css"));
//            bundles.Add(new StyleBundle("~/Content/styles")
//  .IncludeDirectory("~/startbootstrap-sb-admin-2-1.0.7/bower_components/bootstrap/dist/css", "*.css", true));

//            bundles.Add(new StyleBundle("~/Content/sb_admin")
// .IncludeDirectory("~/startbootstrap-sb-admin-2-1.0.7/dist/css", "*.css", true));
//            bundles.Add(new ScriptBundle("~/bundles/startbootstrap")
//.IncludeDirectory("~/Content", "*.js", true));
//            bundles.Add(new ScriptBundle("~/bundles/scripts")
//.IncludeDirectory("~/Scripts/User", "*.js", true));

//            bundles.Add(new StyleBundle("~/Content/EnterpriseSheet")
//                .IncludeDirectory("~/sheetUI3.2/js/EnterpriseSheet/resources/css", "*.css", true));
//            bundles.Add(new StyleBundle("~/Content/EnterpriseSheet")
//                        .IncludeDirectory("~/sheetUI3.2/js/EnterpriseSheet/resources/css", "*.css", true));

//            bundles.Add(new StyleBundle("~/Content/ext-theme")
//                   .IncludeDirectory("~/sheetUI3.2/js/extjs4.2.1/packages/ext-theme-gray/build/resources", "*.css", true));

//            /*
//             * sb-admin
//             */
//            bundles.Add(new StyleBundle("~/Content/metismenu")
//                .IncludeDirectory("~/startbootstrap-sb-admin-2-1.0.7/bower_components/metisMenu/dist", "*.css", true));
//            bundles.Add(new StyleBundle("~/Content/morris")
//            .IncludeDirectory("~/startbootstrap-sb-admin-2-1.0.7/bower_components/font-awesome/css", "*.css", true));
//            bundles.Add(new StyleBundle("~/Content/demo")
//               .IncludeDirectory("~/sheetUI3.2/js/EnterpriseSheet/demo/resources/css", "*.css", true));


//            //  <link rel="stylesheet" type="text/css" href="~/ext-4.2.1.883/packages/ext-theme-gray/build/resources/ext-theme-gray-all.css" />
//            //<link rel="stylesheet" type="text/css" href="~/EnterpriseSheet/resources/css/common.css" />
//            //<link rel="stylesheet" type="text/css" href="~/EnterpriseSheet/resources/css/sheet.css" />
//            //<link rel="stylesheet" type="text/css" href="~/EnterpriseSheet/resources/css/toolbar.css" />
//            //<link rel="stylesheet" type="text/css" href="~/EnterpriseSheet/resources/css/icon.css" />








//        }

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
                      "~/Content/site.css",
                      "~/sheetUI3.2/js/extjs4.2.1/packages/ext-theme-gray/build/resources/ext-theme-gray-all.css",
                      "~/sheetUI3.2/js/EnterpriseSheet/resources/css/common.css",
                      "~/sheetUI3.2/js/EnterpriseSheet/resources/css/sheet.css",
                      "~/sheetUI3.2/js/EnterpriseSheet/resources/css/toolbar.css",
                      "~/sheetUI3.2/js/EnterpriseSheet/resources/css/icon.css",
                      "~/sheetUI3.2/js/EnterpriseSheet/demo/resources/css/demo.css"));

            bundles.Add(new ScriptBundle("~/Content/scripts").Include(
                        "~/sheetUI3.2/js/extjs4.2.1/ext-all.js",
                        "~/sheetUI3.2/js/extjs4.2.1/locale/ext-lang-en.js",
                        "~/sheetUI3.2/js/EnterpriseSheet/src/language/en.js",
                        "~/sheetUI3.2/js/EnterpriseSheet/src/EnterpriseSheet/Config.js",
                        "~/sheetUI3.2/js/EnterpriseSheet/enterprisesheet.js",
                        "~/sheetUI3.2/js/EnterpriseSheet/src/EnterpriseSheet/api/SheetAPI.js",
                        "~/Scripts/MoveTable/bootstrap-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/userScripts").IncludeDirectory("~/Scripts/User", "*.js", true));

            bundles.Add(new StyleBundle("~/Content/metismenu")
                .IncludeDirectory("~/startbootstrap-sb-admin-2-1.0.7/bower_components/metisMenu/dist", "*.css", true));
            bundles.Add(new StyleBundle("~/Content/morris")
            .IncludeDirectory("~/startbootstrap-sb-admin-2-1.0.7/bower_components/font-awesome/css", "*.css", true));

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                              //"~/startbootstrap-sb-admin-2-1.0.7/bower_components/bootstrap/dist/css/bootstrap.min.css",
                                "~/startbootstrap-sb-admin-2-1.0.7/bower_components/metisMenu/dist/metisMenu.min.css",
                                "~/startbootstrap-sb-admin-2-1.0.7/dist/css/timeline.css",
                                "~/startbootstrap-sb-admin-2-1.0.7/dist/css/sb-admin-2.css",
                               "~/startbootstrap-sb-admin-2-1.0.7/bower_components/morrisjs/morris.css",
                               "~/startbootstrap-sb-admin-2-1.0.7/bower_components/font-awesome/css/font-awesome.min.css"));
            
            //bundles.Add(new StyleBundle("~/Content/styles")
            //  .IncludeDirectory("~/startbootstrap-sb-admin-2-1.0.7/bower_components/bootstrap/dist/css", "*.css", true));

                        bundles.Add(new StyleBundle("~/Content/sb_admin")
             .IncludeDirectory("~/startbootstrap-sb-admin-2-1.0.7/dist/css", "*.css", true));
            //.IncludeDirectory("~/Content", "*.js", true));


        }
    }
}
