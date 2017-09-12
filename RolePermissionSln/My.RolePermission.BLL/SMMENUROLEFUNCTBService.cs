using My.RolePermission.IBLL;
using My.RolePermission.Model;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.BLL
 *文件名：  SMMENUROLEFUNCTBBLL
 *版本号：  V1.0.0.0
 *唯一标识：9848fffe-46d0-4be0-b367-32975611d49d
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/23 21:22:44

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/23 21:22:44
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System.Collections.Generic;
using System.Linq;

namespace My.RolePermission.BLL
{
    public partial class SMMENUROLEFUNCTBService : BaseService<SMMENUROLEFUNCTB>, ISMMENUROLEFUNCTBService
    {
        /// <summary>
        /// 根据SysMenuIdId，获取所有角色菜单操作数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public List<SMFUNCTB> GetByRefSysMenuIdAndSysRoleId(int id, List<int> sysRoleIds)
        {
            if (sysRoleIds.Count < 1)
            {
                return null;
            }
            else if (sysRoleIds.Count == 1)
            {
                int? roleId = sysRoleIds[0];
                return LoadEntities(c => c.MENUID == id && c.FUNC_ID != null && c.ROLEID == roleId).Select(s => s.SMFUNCTB)
                     .Where(o => o.STATUS == "Y" && o.SM_SYSTEM == "A").Distinct().OrderBy(o => o.ORDERCODE).AsQueryable().ToList<SMFUNCTB>();
            }
            else
            {
                return LoadEntities(c => c.MENUID == id && c.FUNC_ID != null && sysRoleIds.Any(a => a == c.ROLEID)).Select(s => s.SMFUNCTB).Distinct()
                     .OrderBy(o => o.ORDERCODE).ToList<SMFUNCTB>();
            }
        }
        /// <summary>
        /// 根据SysRoleIdId，获取所有角色菜单操作数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<SMMENUROLEFUNCTB> GetByRefSysRoleId(int id)
        {
            return LoadEntities(x=>x.ROLEID==id);
        }
    }
}
