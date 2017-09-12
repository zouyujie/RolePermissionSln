using My.RolePermission.Common;
using My.RolePermission.IBLL;
using My.RolePermission.Model;
/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.BLL
 *文件名：  SMROLETBService
 *版本号：  V1.0.0.0
 *唯一标识：badbfe14-e289-48bd-826f-0d35b60bb86d
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/25 18:25:54

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/25 18:25:54
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using My.RolePermission.Model.SearchParam;
using System.Linq.Expressions;
using System.Transactions;
using System.Text;

namespace My.RolePermission.BLL
{
    public partial class SMROLETBService : BaseService<SMROLETB>, ISMROLETBService
    {
        /// <summary>
        /// 多条件搜索角色信息
        /// </summary>
        /// <param name="roleParam">角色查询参数实体</param>
        /// <returns></returns>
        public IQueryable<SMROLETB> LoadSearchEntities(RoleParam roleParam)
        {
            Expression<Func<SMROLETB, bool>> whereLambda = PredicateBuilder.True<SMROLETB>();
            if (!string.IsNullOrEmpty(roleParam.ROLE_NAME))
            {
                whereLambda = whereLambda.And(u => u.ROLE_NAME.Contains(roleParam.ROLE_NAME));
            }
            if (!string.IsNullOrEmpty(roleParam.STATUS))
            {
                whereLambda = whereLambda.And(u => u.STATUS == roleParam.STATUS);
            }
            int count = 0;
            IQueryable<SMROLETB> queryData = null;
            if (!string.IsNullOrEmpty(roleParam.order) && !string.IsNullOrEmpty(roleParam.sort))
            {
                bool isAsc = roleParam.order == "asc" ? true : false;
                queryData = LoadPageEntities<SMROLETB>(roleParam.page, roleParam.rows, out count, whereLambda, roleParam.sort, isAsc);
            }
            else
            {
                queryData = LoadPageEntities<SMROLETB>(roleParam.page, roleParam.rows, out count, whereLambda, roleParam.sort, null);
            }
            roleParam.TotalCount = count;

            foreach (var item in queryData)
            {
                if (item.SMUSERTB != null)
                {
                    item.SysPersonId = string.Empty;
                    foreach (var it in item.SMUSERTB2)
                    {
                        item.SysPersonId += it.USER_NAME + ' ';
                    }
                }
            }
            return queryData;
        }
        public SMROLETB Create(SMROLETB entity)
        {
            foreach (int item in entity.SysPersonId.GetIdSort())
            {
                SMUSERTB sys = this.GetCurrentDbSession.ISMUSERTBRepository.LoadEntities(u => u.USER_ID == item).FirstOrDefault();
                entity.SMUSERTB2.Add(sys);
            }
           return AddEntity(entity);
        }
        public bool Edit(SMROLETB model)
        {
            var entity = LoadEntities(r => r.ROLE_ID == model.ROLE_ID).FirstOrDefault();
            entity.SysPersonId = model.SysPersonId;
            entity.SysPersonIdOld = model.SysPersonIdOld;
            entity.REMARK = model.REMARK;
            entity.ROLE_NAME = model.ROLE_NAME;
            entity.STATUS = model.STATUS;
            entity.UPDATE_TIME = DateTime.Now;
            entity.UPDATE_USER = model.UPDATE_USER;

            List<int> addSysPersonId = new List<int>();
            List<int> deleteSysPersonId = new List<int>();
            DataOfDiffrent.GetDiffrent(entity.SysPersonId.GetIdSort(), entity.SysPersonIdOld.GetIdSort(), ref addSysPersonId, ref deleteSysPersonId);

            if (addSysPersonId != null && addSysPersonId.Count() > 0)
            {
                foreach (var item in addSysPersonId)
                {
                    SMUSERTB sys = this.GetCurrentDbSession.ISMUSERTBRepository.LoadEntities(u => u.USER_ID == item).FirstOrDefault();
                    entity.SMUSERTB2.Add(sys);
                }
            }
            if (deleteSysPersonId != null && deleteSysPersonId.Count() > 0)
            {
                List<SMUSERTB> listEntity = new List<SMUSERTB>();
                foreach (var item in deleteSysPersonId)
                {
                    SMUSERTB sys = this.GetCurrentDbSession.ISMUSERTBRepository.LoadEntities(u => u.USER_ID == item).FirstOrDefault();
                    listEntity.Add(sys);
                }
                foreach (SMUSERTB item in listEntity)
                {
                    entity.SMUSERTB2.Remove(item);//查询数据库
                }
            }
            return EditEntity(entity);
        }
        public bool Delete(SMROLETB entity)
        {
            if (entity.SMUSERTB2.Count > 0)
            {
                entity.SMUSERTB = null;
            }

            var result = this.GetCurrentDbSession.ISMMENUROLEFUNCTBRepository.LoadEntities(x => x.ROLEID == entity.ROLE_ID).ToList();// entity.SMMENUROLEFUNCTB;
            if (result != null && result.Count > 0)
            {
                foreach (var v in result)
                {
                    this.GetCurrentDbSession.ISMMENUROLEFUNCTBRepository.DeleteEntity(v);
                }
            }
           return DeleteEntity(entity);
        }
        #region 分配权限

        public bool SaveCollection(string[] ids, int id)
        {
            char split = '^';
            var data = (
                from f in ids
                where f.Contains(split)
                select f.Substring(0, f.IndexOf(split))
                        ).Union(
                from f in ids
                where !string.IsNullOrWhiteSpace(f) && !f.Contains(split)
                select f);

            using (TransactionScope transactionScope = new TransactionScope())
            {
                List<int> lists = new List<int>();
                if (data != null && data.Count() > 0)
                {
                    foreach (var v in data)
                    {
                        lists.Add(int.Parse(v));
                    }
                }
                //利用编码机制，查询出所有的菜单
                var SysMenusIds = this.GetCurrentDbSession.ISMMENUTBRepository.LoadEntities(w => lists.Contains(w.ID)).Select(s => s.ID).Distinct();

                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("DELETE FROM  SMMENUROLEFUNCTB WHERE ROLEID = {0};", id);//删除该角色的所有的菜单和操作

                foreach (var item in SysMenusIds)
                {//插入菜单
                    builder.AppendFormat("INSERT INTO SMMENUROLEFUNCTB(ROLEID,MENUID) VALUES({0},{1});"
                       , id, item);
                }

                foreach (var item in ids)
                {//插入操作
                    if (item.Contains(split))
                    {
                        builder.AppendFormat("INSERT INTO SMMENUROLEFUNCTB(ROLEID,MENUID,FUNC_ID) VALUES({0},{1},{2});"
                       , id, item.Substring(0, item.IndexOf(split)), item.Substring(item.IndexOf(split) + 1));
                    }
                }
                this.GetCurrentDbSession.ExecuteSql(builder.ToString(), null);
                this.GetCurrentDbSession.SaveChanges();
                transactionScope.Complete();
                return true;
            }
        }

        #endregion
    }
}
