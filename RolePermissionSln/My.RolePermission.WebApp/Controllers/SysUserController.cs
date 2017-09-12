using My.RolePermission.Model;
using My.RolePermission.Model.SearchParam;
using My.RolePermission.WebApp.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My.RolePermission.Common.HtmlHelpers;
using My.RolePermission.Common;

namespace My.RolePermission.WebApp.Controllers
{
    [MyAuthorize]
    public class SysUserController : BaseController
    {
        #region 查询
        //
        // GET: /SysUser/
        //[CompressFilter]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetData(UserInfoParam userInfoParam)
        {
            var queryData = SMUSERTBService.LoadSearchEntities(userInfoParam);
            var data = queryData.Select(u => u.ToPoCo());

            //构造成Json的格式传递
            var result = new { total = data.Count(), rows = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        } 
        #endregion
        public JsonResult Details(int id)
        {
            var result = SMUSERTBService.LoadEntities(x => x.USER_ID == id).ToList();
            var item = result.Select(u => new UserView
            {
                USER_ID = u.USER_ID,
                USER_NAME = u.USER_NAME,
                U_ID = u.U_ID,
                GENDER = u.GENDER,
                STATUS = u.STATUS,
                U_PASSWORD = u.U_PASSWORD,
                CREATION_USER = u.CREATION_USER,
                UPDATE_USER = u.UPDATE_USER,
                CREATION_TIME = u.CREATION_TIME,
                UPDATE_TIME = u.UPDATE_TIME,
                CreateUserName = u.SMUSERTB3==null?string.Empty:u.SMUSERTB3.USER_NAME,
                UpdateUserName = u.SMUSERTB2==null?string.Empty:u.SMUSERTB2.USER_NAME,
                COMPONENT_ID = u.COMPONENT_ID,
                GenderName = u.GENDER.GetGenderName(),
                StatusName = u.STATUS.GetStatusName(),
                RoleNames = u.SMROLETB.Select(x => x.ROLE_NAME).ToList()
            }).FirstOrDefault();
            foreach (var s in item.RoleNames)
            {
                item.SysRoleId += s + "，";
            }

            string usernames = string.IsNullOrWhiteSpace(item.SysRoleId) ? string.Empty : item.SysRoleId.TrimEnd('，');
            item.SysRoleId = usernames;
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        #region 创建
        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        //[SupportFilter]
        public ActionResult Create(string id)
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        //[SupportFilter]
        public ActionResult Create(SMUSERTB entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                entity.CREATION_TIME = DateTime.Now;
                entity.CREATION_USER = UserId;
                entity.U_PASSWORD = xEncrypt.EncryptText(entity.U_PASSWORD);//加密

                string returnValue = string.Empty;

                if (SMUSERTBService.LoadEntities(x => x.U_ID == entity.U_ID).FirstOrDefault() != null)
                {
                    returnValue = "登录名已存在！";
                    return Json(Suggestion.InsertFail + returnValue);
                }

                SMLOG _SMLOG = new SMLOG { OPERATION_TYPE = "N", FUNC_CODE = "010702", USER_ID = UserId, CLASSNAME = this.GetType().ToString() +strCreate };
                List<int> roleIds = entity.SysRoleId.GetIdSort();
                entity.SMROLETB = SMROLETBService.LoadEntities(x => roleIds.Contains(x.ROLE_ID)).ToList();
                var result = SMUSERTBService.AddEntity(entity);

                if (result != null)
                {
                    _SMLOG.REMARK = "用户:" + entity.USER_NAME + Suggestion.InsertSucceed;
                    SMLOGService.AddEntity(_SMLOG);//写入日志 
                    return Json(Suggestion.InsertSucceed);
                }
                else
                {
                    _SMLOG.REMARK = "用户:" + entity.USER_NAME + Suggestion.InsertFail + "原因：" + returnValue;
                    SMLOGService.AddEntity(_SMLOG);//写入日志 
                    //提示插入失败
                    return Json(Suggestion.InsertFail + returnValue);
                }
            }
            return Json(Suggestion.InsertFail + "请核对输入的数据的格式"); //提示输入的数据的格式不对 
        } 
        #endregion
        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        //[SupportFilter]
        public ActionResult Edit(int id)
        {
            if (id<1)
            {
                return null;
            }
            SMUSERTB entity = SMUSERTBService.LoadEntities(x => x.USER_ID == id).FirstOrDefault();
            entity.U_PASSWORD = xEncrypt.DecryptText(entity.U_PASSWORD);//解密
            entity.SurePassword = entity.U_PASSWORD;

            return View(entity);
        }

        /// <summary>
        /// 提交编辑信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="collection">客户端传回的集合</param>
        /// <returns></returns>
        [HttpPost]
        //[SupportFilter]
        public ActionResult Edit(int id, SMUSERTB entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                entity.UPDATE_USER = UserId;
                string returnValue = string.Empty;
                SMLOG _SMLOG = new SMLOG { OPERATION_TYPE = "U", FUNC_CODE = "010702", USER_ID =UserId, CLASSNAME = this.GetType().ToString() +strEdit };
                List<int> oldRoleIds = entity.SysRoleIdOld.GetIdSort();
                List<int> roleIds = entity.SysRoleId.GetIdSort();

                if (SMUSERTBService.UpdateUserInfo(oldRoleIds, entity, roleIds))
                {
                    _SMLOG.REMARK = "用户:" + entity.USER_NAME + Suggestion.UpdateSucceed;
                    SMLOGService.AddEntity(_SMLOG);//写入日志   
                   return Json(Suggestion.UpdateSucceed); //提示更新成功 
                }
                else
                {
                    _SMLOG.REMARK = "用户:" + entity.USER_NAME + Suggestion.UpdateFail + "原因：" + returnValue;
                    SMLOGService.AddEntity(_SMLOG);//写入日志      
                    return Json(Suggestion.UpdateFail + returnValue); //提示更新失败
                }
            }
            return Json(Suggestion.UpdateFail + "请核对输入的数据的格式"); //提示输入的数据的格式不对               
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>   
        [HttpPost]
        //[SupportFilter]
        public ActionResult Delete(FormCollection collection)
        {
            string returnValue = string.Empty;

            int[] deleteId = collection["query"].GetString().ToIntList().ToArray<int>();
            if (deleteId != null && deleteId.Length > 0)
            {
                SMLOG _SMLOG = new SMLOG { OPERATION_TYPE = "D", FUNC_CODE = "010000", USER_ID =UserId, CLASSNAME = this.GetType().ToString() + strDelete };
                int userId = deleteId[0];
                var userInfo = SMUSERTBService.LoadEntities(x => x.USER_ID == userId).FirstOrDefault();
                List<int> roleIds = userInfo.SMROLETB.Select(x=>x.ROLE_ID).ToList();
                var userRoles = SMROLETBService.LoadEntities(x => roleIds.Contains(x.ROLE_ID)).ToList();
                foreach (var v in userRoles)
                {
                    userInfo.SMROLETB.Remove(v);
                }

                if (SMUSERTBService.DeleteEntity(userInfo))
                {
                    _SMLOG.REMARK = "用户:" + GetCurrentAccount().USER_NAME + Suggestion.DeleteSucceed;
                    SMLOGService.AddEntity(_SMLOG);//删除成功，写入日志
                    return Json("OK");
                }
                else
                {
                    _SMLOG.REMARK = "用户:" + GetCurrentAccount().USER_NAME + Suggestion.DeleteFail;
                    SMLOGService.AddEntity(_SMLOG);//删除失败，写入日志
                }
                returnValue = _SMLOG.REMARK;
            }
           
            return Json(returnValue);
        }
    }
}
