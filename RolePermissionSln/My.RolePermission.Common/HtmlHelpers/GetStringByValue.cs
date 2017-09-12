/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Common.HtmlHelpers
 *文件名：  GetGenderName
 *版本号：  V1.0.0.0
 *唯一标识：2ce1ae08-f287-4e3a-b6c3-ea9140296af7
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/24 22:54:53

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/24 22:54:53
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

namespace My.RolePermission.Common.HtmlHelpers
{
    public static class GetStringByValue
    {
        public static string GetGenderName(this string str)
        {
            return str == "M" ? "男" : "女";
        }
        /// <summary>
        /// 根据ID获取状态名称
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetStatusName(this string str)
        {
            switch (str)
            {
                case "Y":
                    return "启用";
                case "N":
                    return "停用";
                case "D":
                    return "删除";
                default:
                    return "未知";

            }
        }
        public static string GetStringByList(this List<string> lst)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var v in lst)
            {
                sb.Append(v + " ");
            }
            return sb.ToString();
        }
    }
}
