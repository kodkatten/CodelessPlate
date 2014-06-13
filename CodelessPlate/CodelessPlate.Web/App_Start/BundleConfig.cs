using System.Web.Optimization;

namespace CodelessPlate
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Codeless").Include(
                 "~/Scripts/DummyScript.js",
                 "~/Scripts/StringFormat.js")
            );
        }
    }
}