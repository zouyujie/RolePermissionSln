using My.RolePermission.IBLL;
using My.RolePermission.Model;
using My.RolePermission.Model.SearchParam;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.BLL
 *文件名：  SMUSERTBBll
 *版本号：  V1.0.0.0
 *唯一标识：b2ca6809-cb30-4292-b040-48aeefbdd408
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouqiongjun@kjy.com
 *创建时间：2016/6/21 7:13:46

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/21 7:13:46
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace My.RolePermission.BLL
{
    public partial class SMUSERTBService : BaseService<SMUSERTB>, ISMUSERTBService
    {
        /// <summary>
        /// 验证用户名和密码是否正确
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>登录成功后的用户信息</returns>
        public SMUSERTB ValidateUser(string userName, string password)
        {
            if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(password))
                return null;

            //获取用户信息,请确定web.config中的连接字符串正确
            return LoadEntities(x => x.U_ID == userName &&x.U_PASSWORD == password && x.STATUS == "Y").FirstOrDefault();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="personName">用户名</param>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>修改密码是否成功</returns>
        public bool ChangePassword(string personName, string oldPassword, string newPassword)
        {
            if (!string.IsNullOrWhiteSpace(personName) && !string.IsNullOrWhiteSpace(oldPassword) && !string.IsNullOrWhiteSpace(newPassword))
            {
                try
                {
                    var person = LoadEntities(p => p.U_ID ==personName && p.U_PASSWORD == oldPassword).FirstOrDefault();
                    person.U_PASSWORD = newPassword;
                    this.GetCurrentDbSession.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            return false;
        }
        /// <summary>
        /// 多条件搜索用户信息
        /// </summary>
        /// <param name="userInfoSearchParam">用户查询参数实体</param>
        /// <returns></returns>
        public IQueryable<SMUSERTB> LoadSearchEntities(UserInfoParam userInfoSearchParam)
        {
            Expression<Func<SMUSERTB, bool>> whereLambda = PredicateBuilder.True<SMUSERTB>();
            if (!string.IsNullOrEmpty(userInfoSearchParam.UserName))
            {
                whereLambda = whereLambda.And(u => u.USER_NAME.Contains(userInfoSearchParam.UserName));
            }
            if (!string.IsNullOrEmpty(userInfoSearchParam.GenderName))
            {
                whereLambda = whereLambda.And(u => u.GENDER == userInfoSearchParam.GenderName);
            }
            if (!string.IsNullOrEmpty(userInfoSearchParam.StatusName))
            {
                whereLambda = whereLambda.And(u => u.STATUS == userInfoSearchParam.StatusName);
            }
            int count = 0;
            IQueryable<SMUSERTB> queryData = null;
            if (!string.IsNullOrEmpty(userInfoSearchParam.order) && !string.IsNullOrEmpty(userInfoSearchParam.sort))
            {
                bool isAsc = userInfoSearchParam.order == "asc" ? true : false;
                queryData = LoadPageEntities<SMUSERTB>(userInfoSearchParam.page, userInfoSearchParam.rows, out count, whereLambda, userInfoSearchParam.sort, isAsc);
            }
            else
            {
                queryData = LoadPageEntities<SMUSERTB>(userInfoSearchParam.page, userInfoSearchParam.rows, out count, whereLambda, userInfoSearchParam.sort, null);
            }
            userInfoSearchParam.TotalCount = count;

            foreach (var item in queryData)
            {
                if (item.SMROLETB != null)
                {
                    item.SysRoleId = string.Empty;
                    foreach (var it in item.SMROLETB)
                    {
                        item.SysRoleId += it.ROLE_NAME + ' ';
                    }
                }
            }
            return queryData;
        }
        /// <summary>
        /// 修改用户信息,为用户分配角色
        /// </summary>
        /// <param name="oldRoleIds"></param>
        /// <param name="entity"></param>
        /// <param name="roleIdList"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(List<int> oldRoleIds, SMUSERTB model, List<int> roleIdList)
        {
            var entity = LoadEntities(x => x.USER_ID == model.USER_ID).FirstOrDefault();
            //数据校验
            entity.UPDATE_TIME = DateTime.Now;
            entity.UPDATE_USER = model.UPDATE_USER;
            entity.STATUS = model.STATUS;
            entity.GENDER = model.GENDER;
            entity.U_ID = model.U_ID;
            model.USER_NAME = model.USER_NAME;

            //要删除的
            var dlist = oldRoleIds.Where(p => !roleIdList.Contains(p)).ToList();
            //要添加的
            var alist = roleIdList.Where(p => !oldRoleIds.Contains(p)).ToList();
            var listAll = alist.Union(dlist).Distinct();
            var roleList = this.GetCurrentDbSession.ISMROLETBRepository.LoadEntities(x => listAll.Any(a => a == x.ROLE_ID)).ToList();
            foreach (var v in roleList)
            {
                if (dlist.Contains(v.ROLE_ID))
                {
                    entity.SMROLETB.Remove(v);
                }
                if (alist.Contains(v.ROLE_ID))
                {
                    entity.SMROLETB.Add(v);
                }
            }
           return EditEntity(entity);
        }
    }
}
