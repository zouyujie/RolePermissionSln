using My.RolePermission.Model;
using My.RolePermission.Model.SearchParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My.RolePermission.Common.HtmlHelpers;
using My.RolePermission.Common;

namespace My.RolePermission.WebApp.Controllers
{
    /// <summary>
    /// 操作
    /// </summary>
    public class SysOperationController : BaseController
    {
        static string ClassName = "SysOperationController";
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        //[SupportFilter]
        public ActionResult Index(string view)
        {
            return View();
        }

        /// <summary>
        /// 异步加载数据
        /// </summary>
        [HttpPost]
        public JsonResult GetData(OperationParam operationParam)
        {
            int total = 0;
            var queryData = SMFUNCTBService.LoadSearchEntities(operationParam);
            total = operationParam.TotalCount;

            var data = queryData.ToList().Select(s => new
            {
                FUNC_ID = s.FUNC_ID,
                FUNC_NAME = s.FUNC_NAME,
                EVENT_NAME = s.EVENT_NAME,
                ICONIC = s.ICONIC,
                ORDERCODE = s.ORDERCODE,
                PARENTFUNC_CODE = s.PARENTFUNC_CODE,
                STATUS = s.STATUS.GetStatusName(),
                SM_SYSTEM = s.SM_SYSTEM,
                FUNC_CODE = s.FUNC_CODE,
                CLASS_NAME = s.CLASS_NAME
            });

            //构造成Json的格式传递
            var result = new { total = total, rows = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            SMFUNCTB item = SMFUNCTBService.LoadEntities(f => f.FUNC_ID == id).FirstOrDefault();
            return View(item);
        }

        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(int? id)
        {
            if (id !=null)
            {
                SMMENUTB entityId = SMMENUTBService.LoadEntities(m => m.ID == id).FirstOrDefault();
                if (entityId != null)
                {
                    SMFUNCTB entity = new SMFUNCTB();
                    entity.SysMenuId = id + '&' + entityId.NAME;
                    return View(entity);
                }
            }

            return View();
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(SMFUNCTB entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                string returnValue = string.Empty;
                SMLOG OperLog = new SMLOG { OPERATION_TYPE = "N", FUNC_CODE = "900011", USER_ID =UserId, CLASSNAME = ClassName +strCreate };
                var result = SMFUNCTBService.AddEntity(entity);

                if (result != null)
                {
                    OperLog.REMARK = "操作的信息:(ID:" + entity.FUNC_ID + "名称：" + entity.FUNC_NAME + ")" + Suggestion.InsertSucceed;
                    SMLOGService.AddEntity(OperLog);//写入日志 

                    return Json(Suggestion.InsertSucceed);
                }
                else
                {
                    OperLog.REMARK = "操作的信息:" + entity.FUNC_ID + Suggestion.InsertFail + returnValue;
                    SMLOGService.AddEntity(OperLog);//写入日志 

                    return Json(Suggestion.InsertFail + returnValue); //提示插入失败
                }
            }

            return Json(Suggestion.InsertFail + "，请核对输入的数据的格式"); //提示输入的数据的格式不对 
        }
        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        public ActionResult Edit(int id)
        {
            SMFUNCTB item = SMFUNCTBService.LoadEntities(f=>f.FUNC_ID==id).FirstOrDefault();
            return View(item);
        }
        /// <summary>
        /// 提交编辑信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="collection">客户端传回的集合</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(string id, SMFUNCTB entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                string returnValue = string.Empty;
                SMLOG OperLog = new SMLOG { OPERATION_TYPE = "U", FUNC_CODE = "900012", USER_ID =UserId, CLASSNAME = ClassName +strEdit };
    
                if (SMFUNCTBService.EditEntity(entity))
                {
                    OperLog.REMARK = "操作信息的Id:" + id + Suggestion.UpdateSucceed;
                    SMLOGService.AddEntity(OperLog);//写入日志 

                    return Json(Suggestion.UpdateSucceed); //提示更新成功 
                }
                else
                {
                    OperLog.REMARK = "操作信息的Id:" + id + Suggestion.UpdateFail;
                    SMLOGService.AddEntity(OperLog);//写入日志 

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
        public ActionResult Delete(FormCollection collection)
        {
            string returnValue = string.Empty;
            int[] deleteId = collection["query"].GetString().ToIntList().ToArray<int>();
            if (deleteId != null && deleteId.Length > 0)
            {
                SMLOG OperLog = new SMLOG { OPERATION_TYPE = "D", FUNC_CODE = "900013", USER_ID =UserId, CLASSNAME = ClassName + strDelete };

                if (deleteId.Length == 1)
                {
                    int funcId=deleteId[0];
                    var entity = SMFUNCTBService.LoadEntities(f => f.FUNC_ID == funcId).FirstOrDefault();
                    if (SMFUNCTBService.DeleteEntity(entity))
                    {
                        OperLog.REMARK = "信息的Id为" + deleteId[0] + Suggestion.DeleteSucceed;

                        return Json("OK");
                    }
                    else
                    {
                        OperLog.REMARK = "信息的Id为" + deleteId[0] + Suggestion.DeleteSucceed;
                    }
                    SMLOGService.AddEntity(OperLog);//写入日志 
                }

                #region 批量删除

                //if (OperLog.DeleteCollection(ref validationErrors, deleteId))
                //{
                //    OperLog.REMARK = "操作信息的Id:" + string.Join(",", deleteId) + Suggestion.DeleteSucceed;
                //    LogClassService.WriteServiceLog(OperLog);//写入日志 

                //    return Json("OK");
                //}
                //else
                //{
                //    if (validationErrors != null && validationErrors.Count > 0)
                //    {
                //        validationErrors.All(a =>
                //        {
                //            returnValue += a.ErrorMessage;
                //            return true;
                //        });
                //    }
                //    OperLog.REMARK = "操作信息的Id:" + string.Join(",", deleteId) + Suggestion.DeleteFail + " " + returnValue;
                //    LogClassService.WriteServiceLog(OperLog);//写入日志 
                //}

                #endregion

            }
            return Json(returnValue);
        }

        /// <summary>
        /// 首次设置菜单
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        public ActionResult SetSysMenu(int id)
        {
            var entity = SMFUNCTBService.LoadEntities(m=>m.FUNC_ID==id).FirstOrDefault();
            ViewData["myname"] = entity.FUNC_NAME;
            return View(entity);
        }

        ///// <summary>
        ///// 设置菜单
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult SetSysMenu(SMFUNCTB entity)
        //{
        //    if (entity != null)
        //    {
        //        string returnValue = string.Empty;
        //        SMLOG OperLog = new SMLOG { OPERATION_TYPE = "U", FUNC_CODE = "900010", USER_ID =UserId, CLASSNAME = ClassName + ": SetSysMenu" };

        //        if (OperLog.SetSysMenu(ref validationErrors, entity))
        //        {
        //            OperLog.REMARK = "信息的Id:" + entity.FUNC_ID + Suggestion.UpdateSucceed;
        //            SMLOGService.AddEntity(OperLog);//写入日志 

        //            return Json(Suggestion.UpdateSucceed); //提示更新成功 
        //        }
        //        else
        //        {
        //            OperLog.REMARK = "信息的Id:" + entity.FUNC_ID + Suggestion.DeleteFail + returnValue;
        //            SMLOGService.AddEntity(OperLog);//写入日志 

        //            return Json(Suggestion.UpdateFail + returnValue);
        //        }
        //    }
        //    else
        //    {
        //        return Json(Suggestion.UpdateFail + "，请核对输入的数据的格式"); //提示输入的数据的格式不对               
        //    }
        //}

    }
}
