using log4net;
using My.RolePermission.WebApp.Filter;
using System.Linq;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace My.RolePermission.WebApp
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RemoveWebFormEngines(); //移除WebForm视图引擎
            log4net.Config.XmlConfigurator.Configure();//读取Log4Net配置信息
            MvcHandler.DisableMvcResponseHeader = true; //隐藏ASP.NET MVC版本

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles); //启用文件合并和压缩
            RecordLog();
        }
        void RemoveWebFormEngines()
        {
            var viewEngines = ViewEngines.Engines;
            var webFormEngines = viewEngines.OfType<WebFormViewEngine>().FirstOrDefault();
            if (webFormEngines != null)
            {
                viewEngines.Remove(webFormEngines);
            }
        }
        //采用分布式的方式记录日志
        void RecordLog()
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                while (true)
                {
                    if (MyExceptionAttribute.client.GetListCount("errorMsg") > 0)
                    {
                        string ex = MyExceptionAttribute.client.DequeueItemFromList("errorMsg");
                        ILog logger = LogManager.GetLogger("errorMsg");
                        logger.Error(ex);
                    }
                    else
                    {
                        Thread.Sleep(3000);//如果队列中没有数据，休息避免造成CPU的占用.
                    }
                }
            });
        }
    }
}