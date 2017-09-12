/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Model
 *文件名：  Account
 *版本号：  V1.0.0.0
 *唯一标识：09438b33-b7cc-46b6-a446-38ba1a10a57b
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouqiongjun@kjy.com
 *创建时间：2016/6/21 6:26:01

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/21 6:26:01
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
    /// 登录的用户信息
    /// </summary>
    public class Account
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int USER_ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string USER_NAME { get; set; }
        /// <summary>
        /// 登录的用户名
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// 角色的集合
        /// </summary>
        public List<int> RoleIds { get; set; }

        /// <summary>
        /// 菜单的集合
        /// </summary>
        public List<int> MenuIds { get; set; }

        /// <summary>
        /// 行业编码
        /// </summary>
        public string GuidCode { get; set; }

    }
}
