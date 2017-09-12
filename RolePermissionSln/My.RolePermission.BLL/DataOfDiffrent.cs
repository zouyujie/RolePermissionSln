/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.BLL
 *文件名：  DataOfDiffrent
 *版本号：  V1.0.0.0
 *唯一标识：97280f7a-a425-4bad-bac4-c311ee000be1
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/25 18:32:24

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/25 18:32:24
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace My.RolePermission.BLL
{
    /// <summary>
    /// 多对多数据关系中使用
    /// </summary>
    public class DataOfDiffrent
    {
        /// <summary>
        /// 多对多数据关系中，主键为string类型
        /// </summary>
        /// <param name="newId">新的主键</param>
        /// <param name="oldId">已有的主键</param>
        /// <param name="addId">新增加的主键</param>
        /// <param name="deleteId">删除的主键</param>
        public static void GetDiffrent(List<int> newId, List<int> oldId, ref List<int> addId, ref List<int> deleteId)
        {
            addId = (from n in newId
                     where oldId.All(a => (a != n))
                     where n > 0
                     select n).ToList();

            deleteId = (from o in oldId
                        where newId.All(a => (a != o))
                        where o > 0
                        select o).ToList();
        }
        /// <summary>
        /// 多对多数据关系中，主键为int类型
        /// </summary>
        /// <param name="newId">新的主键</param>
        /// <param name="oldId">已有的主键</param>
        /// <param name="addId">新增加的主键</param>
        /// <param name="deleteId">删除的主键</param>
        public static void GetDiffrentInt(List<string> newId, List<string> oldId, ref List<int> addId, ref List<int> deleteId)
        {
            addId = (from n in newId
                     where oldId.All(a => (a != n))
                     where !string.IsNullOrWhiteSpace(n)
                     select Convert.ToInt32(n)).ToList();

            deleteId = (from o in oldId
                        where newId.All(a => (a != o))
                        where !string.IsNullOrWhiteSpace(o)
                        select Convert.ToInt32(o)).ToList();
        }
    }
}
