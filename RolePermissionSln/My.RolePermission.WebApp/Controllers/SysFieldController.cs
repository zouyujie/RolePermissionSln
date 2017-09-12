using My.RolePermission.Common;
using My.RolePermission.Model;
using My.RolePermission.Model.SearchParam;
using My.RolePermission.WebApp.Filter;
using System;
using System.Linq;
using System.Web.Mvc;

namespace My.RolePermission.WebApp.Controllers
{
    /// <summary>
    /// 数据字典
    /// </summary>
    [MyAuthorize]
    public class SysFieldController : BaseController
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
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
        public JsonResult GetData(FieldParam fieldParam)
        {
            var queryData = SMFIELDService.LoadSearchEntities(fieldParam);
            return Json(new datagrid
            {
                total = fieldParam.TotalCount,
                rows = queryData.Select(s => new
                {
                    ID = s.ID,
                    MYTEXTS = s.MYTEXTS,
                    PARENTID = s.PARENTID,
                    MYTABLES = s.MYTABLES,
                    MYCOLUMS = s.MYCOLUMS,
                    SORT = s.SORT,
                    REMARK = s.REMARK,
                    CREATETIME = s.CREATETIME,
                    CREATEPERSON = s.CREATEPERSON,
                    UPDATETIME = s.UPDATETIME,
                    UPDATEPERSON = s.UPDATEPERSON
                }
                    )
            });
        }
        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            SMFIELD item = SMFIELDService.LoadEntities(x=>x.ID==id).FirstOrDefault();
            return View(item);
        }

        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
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
        public ActionResult Create(SMFIELD entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                string currentPerson = GetCurrentAccount().UID;
                entity.CREATETIME = DateTime.Now;
                entity.CREATEPERSON = currentPerson;

                string returnValue = string.Empty;
                
                SMLOG _SMLOG = new SMLOG { OPERATION_TYPE = "N",FUNC_CODE = "010021",USER_ID = UserId,CLASSNAME = this.GetType().ToString() +strCreate};

                if (SMFIELDService.AddEntity(entity)!=null)
                {
                    _SMLOG.REMARK = "数据字典:" + entity.MYTEXTS + Suggestion.InsertSucceed;
                    SMLOGService.AddEntity(_SMLOG);//写入日志 

                    return Json(Suggestion.InsertSucceed);
                }
                else
                {
                    _SMLOG.REMARK = "数据字典的信息:" + returnValue + Suggestion.InsertFail;
                    SMLOGService.AddEntity(_SMLOG);//写入日志 

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
            SMFIELD item = SMFIELDService.LoadEntities(x => x.ID == id).FirstOrDefault();
            return View(item);
        }
        /// <summary>
        /// 提交编辑信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="collection">客户端传回的集合</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(SMFIELD entity)
        {
            if (entity != null && ModelState.IsValid)
            {   //数据校验

                string currentPerson = GetCurrentAccount().UID;
                entity.UPDATETIME = DateTime.Now;
                entity.UPDATEPERSON = currentPerson;

                string returnValue = string.Empty;
                SMLOG _SMLOG = new SMLOG { OPERATION_TYPE = "U", FUNC_CODE = "010022", USER_ID = UserId, CLASSNAME = this.GetType().ToString() +strEdit };

                if (SMFIELDService.EditEntity(entity))
                {
                    _SMLOG.REMARK = "数据字典:" + entity.MYTEXTS + Suggestion.UpdateSucceed;
                    SMLOGService.AddEntity(_SMLOG);//写入日志 

                    return Json(Suggestion.UpdateSucceed); //提示更新成功 
                }
                else
                {
                    _SMLOG.REMARK = "数据字典:" + entity.MYTEXTS + Suggestion.UpdateFail + returnValue;

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
            string[] deleteId = collection["query"].GetString().Split(',');
            if (deleteId != null && deleteId.Length > 0)
            {
                SMLOG _SMLOG = new SMLOG { OPERATION_TYPE = "D", FUNC_CODE = "010023", USER_ID = UserId, CLASSNAME = this.GetType().ToString() + strDelete };

                if (deleteId.Length == 1)
                {
                    int delId= int.Parse(deleteId[0]);
                    var entity = SMFIELDService.LoadEntities(x => x.ID == delId).FirstOrDefault();
                    if (SMFIELDService.DeleteEntity(entity))
                    {
                        _SMLOG.REMARK = "数据字典信息的Id为" + deleteId[0] + Suggestion.DeleteSucceed;
                        SMLOGService.AddEntity(_SMLOG);//写入日志 

                        return Json("OK");
                    }
                    else
                    {
                        _SMLOG.REMARK = "数据字典信息的Id为" + deleteId[0] + Suggestion.DeleteSucceed;
                    }
                    SMLOGService.AddEntity(_SMLOG);//写入日志 
                }

                #region 批量删除

                //if (SMFIELDService.DeleteCollection(ref validationErrors, deleteId))
                //{
                //    LogClassModels.WriteServiceLog(Suggestion.DeleteSucceed + "，信息的Id为" + string.Join(",", deleteId), "消息"
                //        );//删除成功，写入日志
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
                //    LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息"
                //        );//删除失败，写入日志
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
        public ActionResult GetAllMetadata(int id=0)
        {
            IQueryable<SMFIELD> rows = SMFIELDService.GetAllMetadata(id);
            if (rows.Any())
            {
                //是否可以省
                return Json(new treegrid
                {
                    rows = rows.Select(s =>
                        new
                        {
                            ID = s.ID
                    ,
                            MYTEXTS = s.MYTEXTS
                    ,
                            _parentId = s.PARENTID
                    ,
                            state = s.SMFIELD1.Any(a => a.PARENTID == s.ID) ? "closed" : null
                    ,
                            MYTABLES = s.MYTABLES
                    ,
                            MYCOLUMS = s.MYCOLUMS
                    ,
                            SORT = s.SORT
                    ,
                            REMARK = s.REMARK
                    ,
                            CREATETIME = s.CREATETIME
                    ,
                            CREATEPERSON = s.CREATEPERSON
                    ,
                            UPDATETIME = s.UPDATETIME
                    ,
                            UPDATEPERSON = s.UPDATEPERSON

                        }
                        ).OrderBy(o => o.ID)
                });
            }
            return Content("[]");
        }

    }
}
