using My.RolePermission.Model;
using My.RolePermission.Model;
using My.RolePermission.Model.SearchParam;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.IBLL
 *文件名：  ISMMENUTBBll
 *版本号：  V1.0.0.0
 *唯一标识：1ea80237-277a-4dd8-81ad-ff4c80292b55
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouqiongjun@kjy.com
 *创建时间：2016/6/21 21:09:09

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/21 21:09:09
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
    public partial interface ISMMENUTBService
    {
        /// <summary>
        /// 多条件搜索角色信息
        /// </summary>
        /// <param name="menuParam">查询参数实体</param>
        /// <returns></returns>
        IQueryable<SMMENUTB> LoadSearchEntities(MenuParam menuParam);
        /// <summary>
        /// 根据PersonId获取已经启用的菜单
        /// </summary>
        /// <param name="personId">人员的Id</param>
        /// <returns>菜单拼接的字符串</returns>
        string GetMenuByAccount(ref Account person);
        SMMENUTB Create(SMMENUTB entity);
        /// <summary>
        /// 编辑一个菜单
        /// </summary>
        bool Edit(SMMENUTB entity);
        bool Delete(SMMENUTB entity);
        IQueryable<SMMENUTB> GetAllMetadata();
    }
}
