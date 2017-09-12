using My.RolePermission.Common;
using My.RolePermission.IBLL;
using My.RolePermission.Model;
using My.RolePermission.Model.SearchParam;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.BLL
 *文件名：  SMFIELDService
 *版本号：  V1.0.0.0
 *唯一标识：be38cdaf-7325-4765-8127-9fdadca8d4ce
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/26 7:43:35

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/26 7:43:35
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace My.RolePermission.BLL
{
    public partial class SMFIELDService:BaseService<SMFIELD>, ISMFIELDService
    {
        /// <summary>
        /// 多条件搜索数据字典信息
        /// </summary>
        /// <param name="fieldParam">数据字典查询参数实体</param>
        /// <returns></returns>
        public IQueryable<SMFIELD> LoadSearchEntities(FieldParam fieldParam)
        {
            Expression<Func<SMFIELD, bool>> whereLambda = PredicateBuilder.True<SMFIELD>();
            if (!string.IsNullOrEmpty(fieldParam.MYTEXTS))
            {
                whereLambda = whereLambda.And(u => u.MYTEXTS == fieldParam.MYTEXTS);
            }
            int count = 0;
            IQueryable<SMFIELD> queryData = null;
            if (!string.IsNullOrEmpty(fieldParam.order) && !string.IsNullOrEmpty(fieldParam.sort))
            {
                bool isAsc = fieldParam.order == "asc" ? true : false;
                queryData = LoadPageEntities<SMFIELD>(fieldParam.page, fieldParam.rows, out count, whereLambda, fieldParam.sort, isAsc);
            }
            else
            {
                queryData = LoadPageEntities<SMFIELD>(fieldParam.page, fieldParam.rows, out count, whereLambda, fieldParam.sort, null);
            }
            fieldParam.TotalCount = count;

            foreach (var item in queryData)
            {
                if (item.PARENTID != null && item.SMFIELD2 != null)
                {
                    item.ParentIdOld = item.SMFIELD2.MYTEXTS.GetString();//                            
                }
            }
            return queryData;
        }
        /// <summary>
        /// 获取自连接树形列表数据
        /// </summary>
        /// <returns>自定义的树形结构</returns>
        public IQueryable<SMFIELD> GetAllMetadata(int id)
        {
            if (id == 0)
            {
                return LoadEntities(w => w.PARENTID == null).AsQueryable();
            }
            else
            {
                return LoadEntities(w => w.PARENTID == id).AsQueryable();
            }
        }

        #region MyRegion
         /// <summary>
        /// 获取下拉框的数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="colum">列明</param>
        /// <param name="parentId">父节点编号</param>
        /// <returns></returns>
        public List<SMFIELD> GetSysField(string table, string colum, string parentMyTexts)
        {
           return  LoadEntities(m=>m.MYTABLES == table && m.MYCOLUMS == colum && m.SMFIELD2.MYTEXTS == parentMyTexts)
                .OrderBy(m => m.SORT).ToList();
        }
        /// <summary>
        /// 获取下拉框的数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="colum">列明</param>
        /// <returns></returns>
        public List<SMFIELD> GetSysField(string table, string colum)
        {
            return LoadEntities(m => m.MYTABLES == table && m.MYCOLUMS == colum)
                .OrderBy(m => m.SORT).ToList();
        }
        /// <summary>
        /// 根据父亲的Id，获取数据字典
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        public List<SMFIELD> GetSysFieldByParentId(int id)
        {
            if (id==0)
            {
                return null;
            }
           return LoadEntities(m => m.PARENTID == id).OrderBy(m => m.SORT).ToList();

        }
        /// <summary>
        /// 根据父亲的Id，获取数据字典
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        public List<SMFIELD> GetSysFieldByParent(string id, string parentid, string value)
        {
           return LoadEntities(m => m.MYCOLUMS == id && m.SMFIELD2.MYCOLUMS == parentid && m.SMFIELD2.MYTEXTS == value).ToList();
        }
        /// <summary>
        /// 根据主键id，获取数据字典的展示字段
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        public string GetMyTextsById(int id)
        {
            return LoadEntities(s => s.ID == id).Select(s => s.MYTEXTS).FirstOrDefault();
        }
        #endregion
    }
}
