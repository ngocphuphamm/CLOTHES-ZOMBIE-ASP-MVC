using System.Web;
using System.Web.Optimization;

namespace ClothesWebNET
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           /* bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
           */




            //layout
            bundles.Add(new StyleBundle("~/Content/layout").Include(
                     "~/Content/base.css",
                     "~/Content/header.css", "~/Content/footer.css"));

            //main
            bundles.Add(new StyleBundle("~/Content/main").Include(
                           "~/Content/main.css"));
            //base
            bundles.Add(new StyleBundle("~/Content/base").Include(
                         "~/Content/base.css"));
            //footer
            bundles.Add(new StyleBundle("~/Content/footer").Include(
                       "~/Content/footer.css"));


            //cart (cart + main), js (cart,calculate)
            bundles.Add(new StyleBundle("~/Content/cart").Include(
                          "~/Content/cart.css"));

            //checkout 
            bundles.Add(new StyleBundle("~/Content/checkout").Include(
                         "~/Content/checkout.css"));

            //detail (main+detail) js (product, calculate, detail)
            bundles.Add(new StyleBundle("~/Content/detail").Include(
                   "~/Content/detail.css"));

            //product
            bundles.Add(new StyleBundle("~/Content/product").Include(
                 "~/Content/product.css"));






            bundles.Add(new ScriptBundle("~/bundles/index").Include("~/Scripts/index.js"));
            bundles.Add(new ScriptBundle("~/bundles/product").Include("~/Scripts/product.js"));
            bundles.Add(new ScriptBundle("~/bundles/cart").Include("~/Scripts/cart.js"));
            bundles.Add(new ScriptBundle("~/bundles/calculate").Include("~/Scripts/calculate.js"));
            bundles.Add(new ScriptBundle("~/bundles/checkout").Include("~/Scripts/checkout.js"));
            bundles.Add(new ScriptBundle("~/bundles/detail").Include("~/Scripts/detail.js"));
        }
    }
}
