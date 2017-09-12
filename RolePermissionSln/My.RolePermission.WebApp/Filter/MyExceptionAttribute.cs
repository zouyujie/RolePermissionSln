/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.WebApp.Filter
 *文件名：  MyExceptionAttribute
 *版本号：  V1.0.0.0
 *唯一标识：6882dbde-b2ff-467e-b983-63c5a0fa2434
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/26 20:56:03

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/26 20:56:03
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System.Web.Mvc;
using ServiceStack.Redis;

namespace My.RolePermission.WebApp.Filter
{
    public class MyExceptionAttribute: HandleErrorAttribute
    {
        public static RedisClient client = new RedisClient("127.0.0.1", 6379);//发布到正式环境时，记得更改IP地址和默认端口，并且设置密码
        #region 如果设置密码
        //static string host = "127.0.0.1";/*访问host地址*/
        //static string password = "2016@Test.88210_yujie";/*实例id:密码*/
        //static readonly RedisClient client = new RedisClient(host, 6379, password); 
        #endregion
        //public static IRedisTypedClient<string> redis = client.As<string>(); //复杂对象

        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            client.EnqueueItemOnList("errorMsg", filterContext.Exception.ToString());

            //filterContext.HttpContext.Response.Redirect("/Error.html");
        }
    }
}