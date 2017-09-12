using My.RolePermission.Common;
using My.RolePermission.Model;
using My.RolePermission.Model.SearchParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace My.RolePermission.WebApp.Controllers
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class SysMenuController : BaseController
    {
        string ClassName = "SysMenuController";
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
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
        //[SupportFilter]
        public JsonResult GetData(MenuParam menuParam)
        {
            int total = 0;
            var queryData = SMMENUTBService.LoadSearchEntities(menuParam);
            total = menuParam.TotalCount;

            //构造成Json的格式传递
            var result = new { total = total, rows = queryData };
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 查看详细
        /// </summary> SMLOGService.AddEntity
        /// <param name="id"></param>
        /// <returns></returns>
        //[SupportFilter]
        public ActionResult Details(int id)
        {
            SMMENUTB item = SMMENUTBService.LoadEntities(m => m.ID == id).FirstOrDefault();
            item.STATE = item.STATE == "Y" ? "启用" : "禁用";

            return View(item);
        }

        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        //[SupportFilter]
        public ActionResult Create()
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
        public ActionResult Create(SMMENUTB entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                entity.CREATETIME = DateTime.Now;
                entity.CREATEPERSON = GetCurrentAccount().USER_NAME;

                string returnValue = string.Empty;

                SMLOG OperLog = new SMLOG { OPERATION_TYPE = "N", FUNC_CODE = "900001", USER_ID =UserId, CLASSNAME = ClassName +strCreate };
                var result = SMMENUTBService.Create(entity);

                if (result!=null)
                {
                    OperLog.REMARK = "菜单:" + entity.NAME + Suggestion.InsertSucceed;

                    SMLOGService.AddEntity(OperLog);//写入日志 
                    return Json(Suggestion.InsertSucceed);
                }
                else
                {
                    OperLog.REMARK = "菜单:" + entity.NAME + Suggestion.InsertFail;
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
        //[SupportFilter]
        public ActionResult Edit(int id)
        {
            SMMENUTB item = SMMENUTBService.LoadEntities(m => m.ID == id).FirstOrDefault();

            return View(item);
        }
        /// <summary>
        /// 提交编辑信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="collection">客户端传回的集合</param>
        /// <returns></returns>
        [HttpPost]
        //[SupportFilter]
        public ActionResult Edit(string id, SMMENUTB entity)
        {
            if (entity != null && ModelState.IsValid)
            {   //数据校验
                entity.UPDATETIME = DateTime.Now;
                entity.UPDATEPERSON = GetCurrentAccount().USER_NAME;

                string returnValue = string.Empty;

                SMLOG OperLog = new SMLOG { OPERATION_TYPE = "U", FUNC_CODE = "900002", USER_ID =UserId, CLASSNAME = ClassName +strEdit };

                if (SMMENUTBService.Edit(entity))
                {
                    OperLog.REMARK = "菜单:" + entity.NAME + Suggestion.UpdateSucceed;
                    SMLOGService.AddEntity(OperLog);//写入日志 

                    return Json(Suggestion.UpdateSucceed); //提示更新成功 
                }
                else
                {
                    OperLog.REMARK = "菜单:" + entity.NAME + Suggestion.UpdateFail;
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
        //[SupportFilter]
        public ActionResult Delete(FormCollection collection)
        {
            string returnValue = string.Empty;
            List<int> lists = collection["query"].GetString().ToIntList();
            int[] deleteIds = lists.ToArray();

            if (deleteIds != null && deleteIds.Length > 0)
            {
                SMLOG OperLog = new SMLOG { OPERATION_TYPE = "D", FUNC_CODE = "900003", USER_ID =UserId, CLASSNAME = ClassName + strDelete };

                if (deleteIds.Length == 1)
                {
                    int menuId = deleteIds[0];
                    var entity = SMMENUTBService.LoadEntities(m => m.ID == menuId).FirstOrDefault();
                    if (SMMENUTBService.Delete(entity))
                    {
                        OperLog.REMARK = "菜单Id：" + deleteIds[0] + Suggestion.DeleteSucceed;
                        SMLOGService.AddEntity(OperLog);//写入日志 

                        return Json("OK");
                    }
                    else
                    {
                        OperLog.REMARK = "菜单Id：" + deleteIds[0] + Suggestion.DeleteSucceed;
                    }
                    SMLOGService.AddEntity(OperLog);//写入日志 
                }

                #region 批量删除

                //if (_menuService.DeleteCollection(ref validationErrors, deleteIds))
                //{
                //    OperLog.REMARK = "菜单信息的Id:" + string.Join(",", deleteIds) + Suggestion.DeleteSucceed;
                //    SMLOGService.AddEntity(OperLog);//写入日志 

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
                //    OperLog.REMARK = "菜单信息的Id:" + string.Join(",", deleteIds) + Suggestion.DeleteFail + " " + returnValue;
                //    SMLOGService.AddEntity(OperLog);//写入日志 
                //}
                #endregion
            }
            return Json(returnValue);
        }

        /// <summary>
        /// 获取树形列表的数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetAllMetadata()
        {
            IQueryable<SMMENUTB> rows = SMMENUTBService.GetAllMetadata();

            if (rows.Any())
            {//是否可以省
                return Json(new treegrid
                {
                    rows = rows.Select(s =>
                        new
                        {
                            ID = s.ID
                    ,
                            NAME = s.NAME
                    ,
                            _parentId = s.PARENTID
                                ,
                            state = s.ISLEAF == "Y" ? "null" : "closed"
                    ,
                            URL = s.URL
                    ,
                            iconCls = s.ICONIC
                    ,
                            SORT = s.SORT
                    ,
                            REMARK = s.REMARK
                    ,
                            STATE = s.STATE == "Y" ? "启用" : "停用"
                    ,
                            CREATEPERSON = s.CREATEPERSON
                    ,
                            CREATETIME = s.CREATETIME
                    ,
                            UPDATETIME = s.UPDATETIME
                    ,
                            UPDATEPERSON = s.UPDATEPERSON

                        }
                        ).OrderBy(o => o.SORT)
                });
            }
            return Content("[]");
        }

        /// <summary>
        /// 获取树形列表的数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetAllMetadata2(string id)
        {
            var rows = SMMENUTBService.GetAllMetadata().ToList().Select(s =>
                        new
                        {
                            ID = s.ID
                    ,
                            NAME = s.NAME
                    ,
                            _parentId = s.PARENTID
                    ,
                            isCheck = string.Join(",", s.SMFUNCTB.Select(t => t.FUNC_ID + "^" + t.FUNC_NAME))
                    ,
                            iconCls = s.ICONIC

                        }
                        ).OrderBy(o => o.ID);

            return Json(new treegrid() { rows = rows });
        }

        /// <summary>
        /// 获取树形列表的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllMetadata23(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            var data = SMMENUROLEFUNCTBService.GetByRefSysRoleId(int.Parse(id));
            var rows = data.ToList().Select(s => (s.FUNC_ID == null) ? s.MENUID.ToString() : s.MENUID + "^" + s.FUNC_ID);

            return Json(rows, JsonRequestBehavior.AllowGet);
        }
    }
}
