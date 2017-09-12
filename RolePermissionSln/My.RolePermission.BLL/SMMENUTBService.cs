/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.BLL
 *文件名：  SMMENUTBBll
 *版本号：  V1.0.0.0
 *唯一标识：10db7642-fcaa-470e-8b49-dc08a212a709
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouqiongjun@kjy.com
 *创建时间：2016/6/21 6:32:53

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/21 6:32:53
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.RolePermission.Model;
using My.RolePermission.IBLL;
using My.RolePermission.Model.SearchParam;
using System.Linq.Expressions;
using My.RolePermission.Common;

namespace My.RolePermission.BLL
{
    public partial class SMMENUTBService : BaseService<SMMENUTB>, ISMMENUTBService
    {
        /// <summary>
        /// 多条件搜索角色信息
        /// </summary>
        /// <param name="menuParam">查询参数实体</param>
        /// <returns></returns>
        public IQueryable<SMMENUTB> LoadSearchEntities(MenuParam menuParam)
        {
            Expression<Func<SMMENUTB, bool>> whereLambda = PredicateBuilder.True<SMMENUTB>();
            int count = 0;
            IQueryable<SMMENUTB> queryData = null;
            if (!string.IsNullOrEmpty(menuParam.order) && !string.IsNullOrEmpty(menuParam.sort))
            {
                bool isAsc = menuParam.order == "asc" ? true : false;
                queryData = LoadPageEntities<SMMENUTB>(menuParam.page, menuParam.rows, out count, whereLambda, menuParam.sort, isAsc);
            }
            else
            {
                queryData = LoadPageEntities<SMMENUTB>(menuParam.page, menuParam.rows, out count, whereLambda, menuParam.sort, null);
            }
            menuParam.TotalCount = count;

            return queryData;
        }
        /// <summary>
        /// 根据PersonId获取已经启用的菜单
        /// </summary>
        /// <param name="personId">人员的Id</param>
        /// <returns>菜单拼接的字符串</returns>
        public string GetMenuByAccount(ref Account person)
        {
            int personId = person.USER_ID;
            var roleIds = this.GetCurrentDbSession.ISMUSERTBRepository.LoadEntities(x => x.USER_ID == personId).FirstOrDefault().SMROLETB.Select(s => s.ROLE_ID).ToList();
            person.RoleIds = roleIds;
            List<SMMENUTB> menuNeed = GetCurrentDbSession.ISMMENUROLEFUNCTBRepository.LoadEntities(x => x.FUNC_ID == null && roleIds.Any(a => a == x.ROLEID)).Select(s => s.SMMENUTB).Distinct().OrderBy(o => o.SORT).ToList();
            person.MenuIds = menuNeed.Select(s => s.ID).ToList();

            StringBuilder strmenu2 = new StringBuilder();//拼接菜单的字符串
            int? lever = 0;//上一个菜单的层级
            int? current = 0;//当前菜单的层级

            foreach (SMMENUTB item in menuNeed)
            {
                current = item.MENULEVEL;//item.REMARK.Length / 4;//按照4位数字的编码格式

                if (current == 1)//加载根目录的菜单
                {
                    //解决ie6下没有滚动条的问题
                    strmenu2.Replace('^', ' ')
                        .Append(string.Format(" <div data-options=@iconCls:'{0}'@ title=@{1}@> <div class=@easyui-panel@ fit=@true@ border=@false@><ul class=@easyui-tree@ >^</ul></div></div>", item.ICONIC, item.NAME));
                }
                else if (current < lever)//进入上一个菜单层级
                {
                    string replace = string.Empty;
                    for (int i = 0; i < lever - current; i++)//减少了几个层级
                    {
                        replace += ("</ul></li>");
                    }
                    strmenu2.Replace("^" + replace, replace + GetNode(item));
                }
                else
                {
                    strmenu2.Replace("^", GetNode(item));
                }
                lever = current;

            }
            return strmenu2.ToString().Replace('@', '"').Replace('^', ' ');
        }

        /// <summary>
        /// 获取节点的字符串
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string GetNode(SMMENUTB item)
        {
            List<string> dataoptions = new List<string>();
            if (!string.IsNullOrWhiteSpace(item.ICONIC))
            {
                dataoptions.Add(string.Format("iconCls:'{0}'", item.ICONIC));
            }

            if (string.IsNullOrWhiteSpace(item.ISLEAF) || item.ISLEAF == "Y")//叶子节点
            {
                return string.Format("<li data-options=@{0}@><a href=@#@ icon=@{1}@ rel=@{2}@ id=@{3}@>{4}</a></li>^", string.Join(",", dataoptions), item.ICONIC, item.URL, item.ID, item.NAME);
            }
            else
            {
                ////此处可以在数据字典中配置，将State字段，配置为下拉框，下拉框其中有一个值是"收缩"
                if (!string.IsNullOrWhiteSpace(item.STATE))//收缩展开 && item.State == "收缩"
                {//菜单默认显示关闭
                    dataoptions.Add(string.Format("state:'closed'"));
                }
                return string.Format("<li data-options=@{0}@><span>{1}</span><ul>^</ul></li>", string.Join(",", dataoptions), item.NAME);
            }
        }

        public SMMENUTB Create(SMMENUTB entity)
        {
            //层级
            var result = LoadEntities(x => x.ID == entity.PARENTID).Select(x => x.MENULEVEL).FirstOrDefault();
            int level = result == null ? 1 : (int)result + 1;
            entity.MENULEVEL = level;

            foreach (int item in entity.SysOperationId.GetIdSort())
            {
                SMFUNCTB sys = this.GetCurrentDbSession.ISMFUNCTBRepository.LoadEntities(x => x.FUNC_ID == item).FirstOrDefault(); //new SMFUNCTB { FUNC_ID = item };
                entity.SMFUNCTB.Add(sys);
            }
           return this.AddEntity(entity);
        }
        /// <summary>
        /// 编辑一个菜单
        /// </summary>
        public bool Edit(SMMENUTB entity)
        {  /*                       
           * 不操作 原有 现有
           * 增加   原没 现有
           * 删除   原有 现没
           */
            var editEntity = LoadEntities(m => m.ID == entity.ID).FirstOrDefault();
            if (editEntity == null)
            {
                return false;
            }

            //层级
            var result =LoadEntities(x => x.ID == entity.PARENTID).Select(x => x.MENULEVEL).FirstOrDefault();
            int level = result == null ? 1 : (int)result + 1;
            editEntity.MENULEVEL = level;

            List<int> addSysOperationId = new List<int>();
            List<int> deleteSysOperationId = new List<int>();
            DataOfDiffrent.GetDiffrent(entity.SysOperationId.GetIdSort(), entity.SysOperationIdOld.GetIdSort(), ref addSysOperationId, ref deleteSysOperationId);
            if (addSysOperationId != null && addSysOperationId.Count() > 0)
            {
                foreach (var item in addSysOperationId)
                {
                    SMFUNCTB sys = this.GetCurrentDbSession.ISMFUNCTBRepository.LoadEntities(x => x.FUNC_ID == item).FirstOrDefault(); //new SMFUNCTB { FUNC_ID = item };
                    editEntity.SMFUNCTB.Add(sys);
                }
            }
            if (deleteSysOperationId != null && deleteSysOperationId.Count() > 0)
            {
                List<SMFUNCTB> listEntity = new List<SMFUNCTB>();
                foreach (var item in deleteSysOperationId)
                {
                    SMFUNCTB sys = this.GetCurrentDbSession.ISMFUNCTBRepository.LoadEntities(x => x.FUNC_ID == item).FirstOrDefault(); //new SMFUNCTB { FUNC_ID = item };
                    listEntity.Add(sys);
                }
                foreach (SMFUNCTB item in listEntity)
                {
                    editEntity.SMFUNCTB.Remove(item);//查询数据库
                }
            }

            return EditEntity(editEntity);
        }
        public bool Delete(SMMENUTB entity)
        {
            if (entity.SMFUNCTB.Count > 0)
            {
                entity.SMFUNCTB = null;
            }
            var result = this.GetCurrentDbSession.ISMMENUROLEFUNCTBRepository.LoadEntities(x => x.MENUID == entity.ID).ToList();
            if (result != null && result.Count > 0)
            {
                foreach (var v in result)
                {
                    this.GetCurrentDbSession.ISMMENUROLEFUNCTBRepository.DeleteEntity(v);
                }
            }
            return DeleteEntity(entity);
        }
        /// <summary>
        /// 获取自连接树形列表数据
        /// </summary>
        /// <returns>自定义的树形结构</returns>
        public IQueryable<SMMENUTB> GetAllMetadata()
        {
            return this.GetCurrentDbSession.ISMMENUTBRepository.LoadEntitiesAll("SMFUNCTB");
        }
    }
}
