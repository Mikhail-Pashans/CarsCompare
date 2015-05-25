using System.Web.Optimization;

namespace CarsCompare.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jQuery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jQuery/jquery.validate.js",
                        "~/Scripts/jQuery/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Bootstrap/bootstrap.js",                                            
                      "~/Scripts/Respond/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/Angular/angular.js",
                      "~/Scripts/Angular/angular-sanitize.js"));

            bundles.Add(new ScriptBundle("~/bundles/ui-bootstrap").Include(
                      "~/Scripts/Bootstrap/ui-bootstrap.js",
                      "~/Scripts/Bootstrap/ui-bootstrap-tpls.js"));

            bundles.Add(new ScriptBundle("~/bundles/select").Include(
                      "~/Scripts/Select/select.js"));

            bundles.Add(new ScriptBundle("~/bundles/customScripts").IncludeDirectory(
                      "~/Scripts/CustomScripts/Modules", "*.js").IncludeDirectory(
                      "~/Scripts/CustomScripts/Controllers", "*.js").IncludeDirectory(
                      "~/Scripts/CustomScripts/Services", "*.js").IncludeDirectory(
                      "~/Scripts/CustomScripts/Filters", "*.js").IncludeDirectory(
                      "~/Scripts/CustomScripts/Models", "*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Css/site.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/Css/Bootstrap/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/ui-bootstrap").Include(
                      "~/Content/Css/Bootstrap/ui-bootstrap-csp.css"));

            bundles.Add(new StyleBundle("~/Content/select").Include(
                      "~/Content/Css/Select/select.css",
                      "~/Content/Css/Select/select2.css"));
        }
    }
}