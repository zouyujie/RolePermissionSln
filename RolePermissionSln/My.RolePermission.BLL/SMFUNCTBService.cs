using My.RolePermission.IBLL;
using My.RolePermission.Model;
using My.RolePermission.Model.SearchParam;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.BLL
 *文件名：  SMFUNCTBService
 *版本号：  V1.0.0.0
 *唯一标识：1739f8c7-b931-410a-a9f6-7d08092f35b9
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/7/16 21:46:54

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/7/16 21:46:54
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System;
using System.Linq;
using System.Linq.Expressions;

namespace My.RolePermission.BLL
{
    public partial class SMFUNCTBService : BaseService<SMFUNCTB>, ISMFUNCTBService
    {
        /// <summary>
        /// 多条件搜索角色信息
        /// </summary>
        /// <param name="operationParam">查询参数实体</param>
        /// <returns></returns>
       public IQueryable<SMFUNCTB> LoadSearchEntities(OperationParam operationParam)
        {
            Expression<Func<SMFUNCTB, bool>> whereLambda = PredicateBuilder.True<SMFUNCTB>();
            if (!string.IsNullOrEmpty(operationParam.FUNC_NAME))
            {
                whereLambda = whereLambda.And(u => u.FUNC_NAME.Contains(operationParam.FUNC_NAME));
            }
            if (!string.IsNullOrEmpty(operationParam.STATUS))
            {
                whereLambda = whereLambda.And(u => u.STATUS == operationParam.STATUS);
            }
            int count = 0;
            IQueryable<SMFUNCTB> queryData = null;
            if (!string.IsNullOrEmpty(operationParam.order) && !string.IsNullOrEmpty(operationParam.sort))
            {
                bool isAsc = operationParam.order == "asc" ? true : false;
                queryData = LoadPageEntities<SMFUNCTB>(operationParam.page, operationParam.rows, out count, whereLambda, operationParam.sort, isAsc);
            }
            else
            {
                queryData = LoadPageEntities<SMFUNCTB>(operationParam.page, operationParam.rows, out count, whereLambda, operationParam.sort, null);
            }
            operationParam.TotalCount = count;

            return queryData;
        }
    }
}
