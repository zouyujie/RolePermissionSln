/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Model.SearchParam
 *文件名：  UserInfoParam
 *版本号：  V1.0.0.0
 *唯一标识：365045ad-2b23-4cd6-9880-e513b80b8456
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/24 21:58:13

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/24 21:58:13
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

namespace My.RolePermission.Model.SearchParam
{
    public class UserInfoParam : BaseParam
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string GenderName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string StatusName { get; set; }
    }
}
