using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FutureSathi.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new ScriptBundle("~/ALLJQ").Include("~/JS/code.jquery.com_jquery-3.7.1.min.js", "~/JS/jquery.dataTables.min.js"));

            bundles.Add(new StyleBundle("~/ALLCSS").Include("~/CSS/css_bootstrap.min.css",
                "~/CSS/jquery.dataTables.min.css"));

            // This line of code enable bundling
            BundleTable.EnableOptimizations = true;
        }
    }
}