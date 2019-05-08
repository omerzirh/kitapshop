using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;


namespace KitapShop.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery.min.js",
                         "~/Scripts/wow.min.js",
                         "~/Scripts/bootstrap.min.js",
                         "~/Scripts/slick.min.js",
                         "~/Scripts/jquery.li-scroller.1.0.js",
                         "~/Scripts/jquery.newsTicker.min.js",
                         "~/Scripts/jquery.fancybox.pack.js",
                         "~/Scripts/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css") .Include(
                "~/Content/theme.css",
                "~/Content/bootstrap.min.css",
                "~/Content/font-awesome.min.css",
                "~/Content/animate.css",
                "~/Content/font.css",
                "~/Content/jquery.fancybox.css",
                "~/Content/li-scroller.css",
                "~/Content/slick.css",
                "~/Content/style.css",
                "~/Content/giris.css",
                "~/Content/Site.css"));
        }
    }
}