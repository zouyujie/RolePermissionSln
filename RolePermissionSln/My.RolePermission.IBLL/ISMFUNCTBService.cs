using My.RolePermission.Model;
using My.RolePermission.Model.SearchParam;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.IBLL
 *文件名：  ISMFUNCTBService
 *版本号：  V1.0.0.0
 *唯一标识：1c6d62ac-d907-4d83-b92a-240adde85118
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/7/16 21:47:31

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/7/16 21:47:31
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System.Linq;

namespace My.RolePermission.IBLL
{
    public partial interface ISMFUNCTBService
    {
        /// <summary>
        /// 多条件搜索角色信息
        /// </summary>
        /// <param name="roleParam">角色查询参数实体</param>
        /// <returns></returns>
        IQueryable<SMFUNCTB> LoadSearchEntities(OperationParam operationParam);
    }
}
