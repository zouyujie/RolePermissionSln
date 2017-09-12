using My.RolePermission.Model;
using My.RolePermission.Model.SearchParam;
using System.Collections.Generic;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.IBLL
 *文件名：  ISMFIELDService
 *版本号：  V1.0.0.0
 *唯一标识：026c7a73-03dd-443a-ab46-f1c93eaa55c2
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/26 7:52:06

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/26 7:52:06
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System.Linq;

namespace My.RolePermission.IBLL
{
    public partial interface ISMFIELDService
    {
        /// <summary>
        /// 多条件搜索数据字典信息
        /// </summary>
        /// <param name="fieldParam">数据字典查询参数实体</param>
        /// <returns></returns>
        IQueryable<SMFIELD> LoadSearchEntities(FieldParam fieldParam);
        /// <summary>
        /// 获取自连接树形列表数据
        /// </summary>
        /// <returns>自定义的树形结构</returns>
        IQueryable<SMFIELD> GetAllMetadata(int id);
        #region MyRegion
        /// <summary>
        /// 获取下拉框的数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="colum">列明</param>
        /// <param name="parentId">父节点编号</param>
        /// <returns></returns>
        List<SMFIELD> GetSysField(string table, string colum, string parentMyTexts);
        /// <summary>
        /// 获取下拉框的数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="colum">列明</param>
        /// <returns></returns>
        List<SMFIELD> GetSysField(string table, string colum);
        /// <summary>
        /// 根据父亲的Id，获取数据字典
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        List<SMFIELD> GetSysFieldByParentId(int id);
        /// <summary>
        /// 根据父亲的Id，获取数据字典
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        List<SMFIELD> GetSysFieldByParent(string id, string parentid, string value);
        /// <summary>
        /// 根据主键id，获取数据字典的展示字段
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        string GetMyTextsById(int id);
        #endregion
    }
}
