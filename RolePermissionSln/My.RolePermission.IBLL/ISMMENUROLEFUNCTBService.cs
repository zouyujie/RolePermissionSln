using My.RolePermission.Model;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.IBLL
 *文件名：  ISMMENUROLEFUNCTBBLL
 *版本号：  V1.0.0.0
 *唯一标识：50de9bb8-8c71-4e50-ae31-15492b3dfa7e
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/23 21:21:04

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/23 21:21:04
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
    public partial interface ISMMENUROLEFUNCTBService
    {
        /// <summary>
        /// 根据SysMenuIdId，获取所有角色菜单操作数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        List<SMFUNCTB> GetByRefSysMenuIdAndSysRoleId(int id, List<int> sysRoleIds);
        IQueryable<SMMENUROLEFUNCTB> GetByRefSysRoleId(int id);
    }
}
