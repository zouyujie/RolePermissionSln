using My.RolePermission.Ioc;
using My.RolePermission.Model;
using My.RolePermission.WebApp.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace My.RolePermission.WebApp.Controllers
{
    [MyAuthorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var result = SMUSERTBService.LoadEntities(x => x.STATUS == "Y").ToList();
            ViewBag.Name =result!=null&&result.Count>0? result.FirstOrDefault().USER_NAME:"";
            Account account = GetCurrentAccount();
            if (account == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewData["PersonName"] = account.UID;

                ViewData["Menu"] = SMMENUTBService.GetMenuByAccount(ref account);// 获取菜单
            }
            return View();
        }
        /// <summary>
        /// 获取列表中的按钮导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetToolbar(int id)
        {
            Account account = GetCurrentAccount();
            if (account == null)
            {
                return Content(" <script type='text/javascript'> window.top.location='Account'; </script>");
            }

            List<SMFUNCTB> sysOperations = SMMENUROLEFUNCTBService.GetByRefSysMenuIdAndSysRoleId(id, account.RoleIds);
            List<toolbar> toolbars = new List<toolbar>();
            foreach (SMFUNCTB item in sysOperations)
            {
                toolbars.Add(new toolbar() { handler = item.EVENT_NAME, iconCls = item.ICONIC, text = item.FUNC_NAME });
            }
            return Json(toolbars, JsonRequestBehavior.AllowGet);
        }
    }
}
