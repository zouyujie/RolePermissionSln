using My.RolePermission.Model;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.IBLL
 *文件名：  ISMUSERTBBll
 *版本号：  V1.0.0.0
 *唯一标识：61b247e4-48d7-46bd-b831-524d5def3a20
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouqiongjun@kjy.com
 *创建时间：2016/6/21 7:12:57

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/21 7:12:57
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
    public partial interface ISMUSERTBService
    {
        bool ChangePassword(string personName, string oldPassword, string newPassword);
        SMUSERTB ValidateUser(string userName, string password);
        /// <summary>
        /// 多条件搜索用户信息
        /// </summary>
        /// <param name="userInfoSearchParam">用户查询参数实体</param>
        /// <returns></returns>
        IQueryable<SMUSERTB> LoadSearchEntities(Model.SearchParam.UserInfoParam userInfoSearchParam);
        /// <summary>
        /// 修改用户信息,为用户分配角色
        /// </summary>
        /// <param name="oldRoleIds"></param>
        /// <param name="entity"></param>
        /// <param name="roleIdList"></param>
        /// <returns></returns>
        bool UpdateUserInfo(List<int> oldRoleIds, SMUSERTB entity, List<int> roleIdList);
    }
}
