/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.WebApp.Filter
 *文件名：  MyAuthorizeAttribute
 *版本号：  V1.0.0.0
 *唯一标识：f904e8a0-a4b6-49c9-aa22-6e2c635ede3b
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/28 20:33:36

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/28 20:33:36
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System.Web.Mvc;
using My.RolePermission.Model;

namespace My.RolePermission.WebApp.Filter
{
    /// <summary>
    /// 授权过滤器 --在Action过滤器前执行
    /// </summary>
    public class MyAuthorizeAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //注释掉父类方法，因为父类里的 OnAuthorization 方法会调用ASP.NET的授权验证机制！
            //base.OnAuthorization(filterContext);

            if (filterContext.HttpContext.Request.Cookies["sessionId"] != null)
            {
                string sessionId = filterContext.HttpContext.Request.Cookies["sessionId"].Value;//接收从Cookie中传递过来的Memcache的key
                object obj = Common.MemcacheHelper.Get(sessionId);//根据key从Memcache中获取用户的信息
                if (obj != null)
                {
                    Account _Account = Common.SerializerHelper.DeserializeToObject<Account>(obj.ToString());
                    //Common.MemcacheHelper.Set(sessionId, obj.ToString(), DateTime.Now.AddMinutes(20));//模拟滑动过期时间
                    if (_Account == null)
                    {
                        filterContext.HttpContext.Response.Redirect("/Error.html");
                        return;
                    }
                }
                else
                {
                    filterContext.HttpContext.Response.Redirect("/Login/Index");
                    return;
                }
            }
        }
    }
}