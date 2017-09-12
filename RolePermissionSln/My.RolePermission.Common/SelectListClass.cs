/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Common
 *文件名：  SelectListClass
 *版本号：  V1.0.0.0
 *唯一标识：ac81eeda-b0df-4a3c-ad11-c5901d14dcd0
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/24 23:02:00

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/24 23:02:00
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
using System.Web.Mvc;

namespace My.RolePermission.Common
{
    public class GloabClass
    {
        /// <summary>
        /// 是否添加选择行
        /// </summary>
        public static bool IsAddSelect = true;
        /// <summary>
        /// //选择行的文本
        /// </summary>
        public static string DefaultSelectText = "——请选择——";
        /// <summary>
        /// //默认选择的值
        /// </summary>
        public static string DefaultSelectValue = "";
        /// <summary>
        /// 默认选择的整数值
        /// </summary>
        public static decimal? DefaultIntValue = null;
    }
    public class SelectListClass : GloabClass
    {
        /// <summary>
        /// 获取性别
        /// </summary>
        /// <returns></returns>
        public static SelectList GetGenders(bool isSelected)
        {
            List<SelectListItem> lists = new List<SelectListItem>();
            if (isSelected == true)
            {
                if (IsAddSelect)
                {
                    lists.Add(new SelectListItem { Text = DefaultSelectValue, Value = DefaultSelectText });
                }
            }
            lists.Add(new SelectListItem { Text = "M", Value = "男" });
            lists.Add(new SelectListItem { Text = "W", Value = "女" });
            return new SelectList(lists, "Text", "Value");
        }
        /// <summary>
        /// 获取所有状态
        /// </summary>
        /// <returns></returns>
        public static SelectList GetStatus(bool isSelected)
        {
            List<SelectListItem> lists = new List<SelectListItem>();
            if (isSelected == true)
            {
                if (IsAddSelect)
                {
                    lists.Add(new SelectListItem { Text = DefaultSelectValue, Value = DefaultSelectText });
                }
            }
            lists.Add(new SelectListItem { Text = "Y", Value = "启用" });
            lists.Add(new SelectListItem { Text = "N", Value = "停用" });
            return new SelectList(lists, "Text", "Value");
        }
        /// <summary>
        /// 获取所有状态
        /// </summary>
        /// <returns></returns>
        public static SelectList GetYesOrNo(bool isSelected)
        {
            List<SelectListItem> lists = new List<SelectListItem>();
            if (isSelected == true)
            {
                if (IsAddSelect)
                {
                    lists.Add(new SelectListItem { Text = DefaultSelectValue, Value = DefaultSelectText });
                }
            }
            lists.Add(new SelectListItem { Text = "Y", Value = "是" });
            lists.Add(new SelectListItem { Text = "N", Value = "否" });
            return new SelectList(lists, "Text", "Value");
        }
    }
}
