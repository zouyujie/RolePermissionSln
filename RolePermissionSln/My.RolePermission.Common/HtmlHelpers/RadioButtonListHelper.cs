/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Common.HtmlHelpers
 *文件名：  RadioButtonListHelper
 *版本号：  V1.0.0.0
 *唯一标识：32d0df85-3437-4ad8-8a05-b3d38629b872
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/25 15:54:42

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/25 15:54:42
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace My.RolePermission.Common.HtmlHelpers
{
    public static class RadioButtonListHelper
    {
        /// <summary>
        /// Radio列表
        /// </summary>
        /// <param name="htmlHelper">辅助类</param>
        /// <param name="selectList">集合</param>
        /// <param name="htmlAttributes">html标签</param>
        /// <param name="isChecked">默认单选状态</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes, bool isChecked = false)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            return RadioButtonList(htmlHelper, name, selectList, htmlAttributes, isChecked);
        }
        /// <summary>
        /// Radio列表
        /// </summary>
        /// <param name="htmlHelper">辅助类</param>
        /// <param name="selectList">集合</param>
        /// <param name="isChecked">默认单选状态</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, bool isChecked = false)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            return RadioButtonList(htmlHelper, name, selectList, new { }, isChecked);
        }

        /// <summary>
        /// Radio列表
        /// </summary>
        /// <param name="htmlHelper">辅助类</param>
        /// <param name="name">字段名称</param>
        /// <param name="selectList">集合</param>
        /// <param name="htmlAttributes">html标签</param>
        /// <param name="isChecked">默认单选状态</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes, bool isChecked = false)
        {
            IDictionary<string, object> HtmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            string defaultValue = string.Empty;
            if (htmlHelper.ViewData.Model != null)
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    defaultValue = htmlHelper.ViewData.Eval(name).GetString();

                }
                isChecked = false;
            }

            StringBuilder str = new StringBuilder();
            foreach (SelectListItem item in selectList)
            {
                str.Append("<input ");
                if (item.Value == defaultValue)
                {
                    str.Append("checked='checked' ");

                }
                if (isChecked)
                {

                    str.Append(" checked=true ");
                    isChecked = false;
                }
                foreach (var bute in HtmlAttributes)
                {
                    str.Append(bute.Key + "=\"" + bute.Value);

                }

                str.Append("\" id=\"" + item.Value + "\" type=\"radio\"  value=\"" + item.Value + "\" name=\"" + name + "\"/>");
                str.Append(item.Text);
            }
            return MvcHtmlString.Create(str.ToString());
        }
    }
}
