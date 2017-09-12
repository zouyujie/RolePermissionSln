using My.RolePermission.Model;
using My.RolePermission.Model.SearchParam;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.IBLL
 *文件名：  ISMLOGService
 *版本号：  V1.0.0.0
 *唯一标识：64dc251e-74bb-4cd3-bbce-1401e9f83be4
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/26 8:05:48

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/26 8:05:48
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.RolePermission.IBLL
{
    public partial interface ISMLOGService
    {
        /// <summary>
        /// 多条件搜索日志信息
        /// </summary>
        /// <param name="logParam">日志查询参数实体</param>
        /// <returns></returns>
        IQueryable<SMLOG> LoadSearchEntities(LogParam logParam);
    }
}
