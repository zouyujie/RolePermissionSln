using My.RolePermission.Model;
using My.RolePermission.Model.SearchParam;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.IBLL
 *文件名：  Class1
 *版本号：  V1.0.0.0
 *唯一标识：7ac9544d-a883-41d0-aedf-1762c984ff68
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/25 18:55:40

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/25 18:55:40
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System.Linq;

namespace My.RolePermission.IBLL
{
    public partial interface ISMROLETBService
    {
        /// <summary>
        /// 多条件搜索角色信息
        /// </summary>
        /// <param name="roleParam">角色查询参数实体</param>
        /// <returns></returns>
        IQueryable<SMROLETB> LoadSearchEntities(RoleParam roleParam);
        SMROLETB Create(SMROLETB entity);
        bool Edit(SMROLETB entity);
        bool Delete(SMROLETB model);
        bool SaveCollection(string[] ids, int id);
    }
}
