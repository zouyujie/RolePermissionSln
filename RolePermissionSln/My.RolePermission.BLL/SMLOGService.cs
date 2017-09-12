using My.RolePermission.IBLL;
using My.RolePermission.Model;
using My.RolePermission.Model.SearchParam;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.BLL
 *文件名：  SMLOGService
 *版本号：  V1.0.0.0
 *唯一标识：d446c197-602c-494b-819d-6dcaa0d15e49
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/26 6:49:55

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/26 6:49:55
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
    public partial class SMLOGService : BaseService<SMLOG>, ISMLOGService
    {
        /// <summary>
        /// 多条件搜索日志信息
        /// </summary>
        /// <param name="logParam">日志查询参数实体</param>
        /// <returns></returns>
        public IQueryable<SMLOG> LoadSearchEntities(LogParam logParam)
        {
            Expression<Func<SMLOG, bool>> whereLambda = PredicateBuilder.True<SMLOG>();
            if (!string.IsNullOrEmpty(logParam.OPERATION_TYPE))
            {
                whereLambda = whereLambda.And(u => u.OPERATION_TYPE == logParam.OPERATION_TYPE);
            }
            if (!string.IsNullOrEmpty(logParam.LOG_DATETIMEStart_Time))
            {
                DateTime startTime = Convert.ToDateTime(logParam.LOG_DATETIMEStart_Time);
                whereLambda = whereLambda.And(u => u.LOG_DATETIME >= startTime);
            }
            if (!string.IsNullOrEmpty(logParam.LOG_DATETIMEEnd_Time))
            {
                DateTime endTime = Convert.ToDateTime(logParam.LOG_DATETIMEEnd_Time);
                whereLambda = whereLambda.And(u => u.LOG_DATETIME <= endTime);
            }
            int count = 0;
            IQueryable<SMLOG> queryData = null;
            if (!string.IsNullOrEmpty(logParam.order) && !string.IsNullOrEmpty(logParam.sort))
            {
                bool isAsc = logParam.order == "asc" ? true : false;
                queryData =LoadPageEntities<SMLOG>(logParam.page, logParam.rows, out count, whereLambda, logParam.sort, isAsc);
            }
            else
            {
                queryData = LoadPageEntities<SMLOG>(logParam.page, logParam.rows, out count, whereLambda, logParam.sort, null);
            }
            logParam.TotalCount = count;

            foreach (var item in queryData)
            {
                item.OperaterTypeName = this.GetCurrentDbSession.ISMFIELDRepository.LoadEntities(x => x.MYTABLES == "SMLOG" && x.MYCOLUMS == "STATUS" && x.MYVALUES == item.OPERATION_TYPE).Select(x => x.MYTEXTS).FirstOrDefault();
            }
            return queryData;
        }
    }
}
