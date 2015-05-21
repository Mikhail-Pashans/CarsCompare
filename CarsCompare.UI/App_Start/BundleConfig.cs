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
                        "~/Scripts/jQuery/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Bootstrap/bootstrap.js",
                      "~/Scripts/Respond/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/Angular/angular.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/customScripts").IncludeDirectory(
                      "~/Scripts/CustomScripts/Modules", "*.js").IncludeDirectory(
                      "~/Scripts/CustomScripts/Controllers", "*.js").IncludeDirectory(
                      "~/Scripts/CustomScripts/Services", "*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Css/bootstrap.css",
                      "~/Content/Css/site.css"));
        }
    }
}