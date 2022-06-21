using System.Web;
using System.Web.Optimization;

namespace ClothesWebNET
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {




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

            //payment
            bundles.Add(new StyleBundle("~/Content/payment").Include(
                     "~/Content/payment.css"));




            //detail (main+detail) js (product, calculate, detail)
            bundles.Add(new StyleBundle("~/Content/detail").Include(
                   "~/Content/detail.css"));

            //product
            bundles.Add(new StyleBundle("~/Content/product").Include(
                 "~/Content/product.css"));

            bundles.Add(new StyleBundle("~/Content/login").Include(
                "~/Content/login.css"));
            bundles.Add(new ScriptBundle("~/bundles/login").Include("~/Scripts/login.js"));
            bundles.Add(new StyleBundle("~/Content/register").Include(
              "~/Content/register.css"));


            bundles.Add(new StyleBundle("~/Content/toastr").Include(
               "~/Content/toastr.css"));


            bundles.Add(new ScriptBundle("~/bundles/index").Include("~/Scripts/index.js"));
            bundles.Add(new ScriptBundle("~/bundles/product").Include("~/Scripts/product.js"));
            bundles.Add(new ScriptBundle("~/bundles/cart").Include("~/Scripts/cart.js"));
            bundles.Add(new ScriptBundle("~/bundles/calculate").Include("~/Scripts/calculate.js"));
            bundles.Add(new ScriptBundle("~/bundles/checkout").Include("~/Scripts/checkout.js"));
            bundles.Add(new ScriptBundle("~/bundles/payment").Include("~/Scripts/payment.js"));
            bundles.Add(new ScriptBundle("~/bundles/detail").Include("~/Scripts/detail.js"));



            /*   admin*/
            bundles.Add(new StyleBundle("~/Content/admin/base").Include(
           "~/Content/admin/base.css"));
            bundles.Add(new StyleBundle("~/Content/admin/bstr").Include(
       "~/Content/admin/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Content/admin/custom").Include(
"~/Content/admin/custom.css"));
            bundles.Add(new StyleBundle("~/Content/admin/index").Include(
"~/Content/admin/index.css"));

            bundles.Add(new StyleBundle("~/Content/admin/style").Include(
"~/Content/admin/style.css"));


            bundles.Add(new ScriptBundle("~/bundles/admin/allproduct").Include("~/Scripts/admin/allproduct.js"));
            bundles.Add(new ScriptBundle("~/bundles/admin/bstr").Include("~/Scripts/admin/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/admin/donhang").Include("~/Scripts/admin/donhang.js"));
            bundles.Add(new ScriptBundle("~/bundles/admin/jquery").Include("~/Scripts/admin/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/admin/main").Include("~/Scripts/admin/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/admin/popper").Include("~/Scripts/admin/popper.js"));
            bundles.Add(new ScriptBundle("~/bundles/admin/header").Include("~/Scripts/admin/header.js"));


            bundles.Add(new ScriptBundle("~/bundles/poppermin", "https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"));





        }
    }
}