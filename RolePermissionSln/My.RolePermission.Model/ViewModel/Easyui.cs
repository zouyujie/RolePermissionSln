/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Common.HtmlHelpers
 *文件名：  Easyui
 *版本号：  V1.0.0.0
 *唯一标识：5f2202a4-f11d-4224-b3c0-ce4b3804ecc1
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/23 21:02:03

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/23 21:02:03
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

namespace My.RolePermission.Model
{
    /// <summary>
    /// easyui中的datagrid
    /// </summary>
    public class datagrid
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int total;
        /// <summary>
        /// 行数据集
        /// </summary>
        public dynamic rows;
    }
    /// <summary>
    /// easyui中的tree
    /// </summary>
    public class treegrid
    {
        /// <summary>
        /// 行数据集
        /// </summary>
        public dynamic rows;
    }
    /// <summary>
    /// 树形列表控件对应的对象
    /// </summary>
    public class SystemTree
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string id;
        /// <summary>
        /// 显示内容
        /// </summary>
        public string text;
        /// <summary>
        /// 图标
        /// </summary>
        public string iconCls;
        /// <summary>
        /// 是否被选中，checked为C#关键字，所以前面加@
        /// </summary>
        public bool @checked = false;
        /// <summary>
        /// 当前是展开还是收缩的状态
        /// </summary>
        public string state;
        /// <summary>
        /// 子节点集合
        /// </summary>
        public List<SystemTree> children = new List<SystemTree>();
    }
    /// <summary>
    /// 列表中的按钮导航
    /// </summary>
    public class toolbar
    {
        /// <summary>
        /// 显示的文本
        /// </summary>
        public string text;
        /// <summary>
        /// 图标
        /// </summary>
        public string iconCls;
        /// <summary>
        /// 处理方法
        /// </summary>
        public string handler;
    }
}
