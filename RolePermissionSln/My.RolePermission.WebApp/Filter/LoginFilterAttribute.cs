using My.RolePermission.Common;
using My.RolePermission.Model;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.WebApp.Filter
 *文件名：  LoginFilterAttribute
 *版本号：  V1.0.0.0
 *唯一标识：2a8175e4-d194-4254-8e03-ac4e60da57d3
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouqiongjun@kjy.com
 *创建时间：2016/6/21 6:44:38

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/21 6:44:38
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System.Web.Mvc;

namespace My.RolePermission.WebApp.Filter
{
    /// <summary>
    /// 登录验证过滤器
    /// </summary>
    public class LoginFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 当Action中标注了[LoginFilter]的时候会执行
        /// </summary>
        /// <param name="filterContext">请求上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (filterContext.HttpContext.Session["account"] == null)
            //{
            //    filterContext.HttpContext.Response.Write(" <script type='text/javascript'> window.top.location='Login'; </script>");
            //    filterContext.Result = new EmptyResult();
            //    return;
            //}
            base.OnActionExecuting(filterContext);
            bool result = false;
            if (filterContext.HttpContext.Request.Cookies["sessionId"] != null)
            {
                string sessionId = filterContext.HttpContext.Request.Cookies["sessionId"].Value;//接收从Cookie中传递过来的Memcache的key
                object obj = Common.MemcacheHelper.Get(sessionId);//根据key从Memcache中获取用户的信息
                if (obj != null)
                {
                    var account = SerializerHelper.DeserializeToObject<Account>(obj.ToString());
                    if (account == null)
                    {
                        result = true;
                    }
                }
                else
                {
                    result = true;
                }
            }
            else
            {
                result = true;
            }
            if(result)
            {
                //filterContext.HttpContext.Response.Write(" <script type='text/javascript'> window.top.location='Login'; </script>");
                filterContext.HttpContext.Response.Redirect("/Login");
                filterContext.Result = new EmptyResult();
                return;
            }
        }
    }
}