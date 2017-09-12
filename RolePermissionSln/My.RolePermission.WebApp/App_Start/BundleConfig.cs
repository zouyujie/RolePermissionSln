using System.Web;
using System.Web.Optimization;

namespace My.RolePermission.WebApp
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            // 使用 Modernizr 的开发版本进行开发和了解信息。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //add 自定义压缩合并
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.unobtrusive*",
            "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jscookie").Include(
"~/DLL/easyUI/jquery.min.js",
"~/DLL/easyUI/jquery.cookie.js"));

            bundles.Add(new ScriptBundle("~/bundles/easyui").Include(
                       //"~/DLL/easyUI/jquery.easyui.min.js",
                       "~/DLL/easyUI/locale/easyui-lang-zh_CN.js",
                       "~/DLL/easyUI/easyuiExt.js",
                       "~/DLL/easyUI/JScriptCommon.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));


            bundles.Add(new StyleBundle("~/Content/Login/css").Include("~/Content/css/bootstrap.min.css", "~/Content/css/signin.css"));
            bundles.Add(new StyleBundle("~/Content/easyUI/css").Include("~/DLL/easyUI/themes/icon.css", "~/DLL/easyUI/themes/bootstrap/easyui.css", "~/DLL/easyUI/easyuiExt.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}