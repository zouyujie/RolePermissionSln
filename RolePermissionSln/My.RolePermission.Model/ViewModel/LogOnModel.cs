/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Model
 *文件名：  LogOnModel
 *版本号：  V1.0.0.0
 *唯一标识：c5016d46-de85-411a-8a33-ac116c0d20f4
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouqiongjun@kjy.com
 *创建时间：2016/6/21 7:08:07

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/21 7:08:07
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.RolePermission.Model
{
    public class LogOnModel
    {
        [Required(ErrorMessage = "请填写用户名")]
        [DisplayName("用户名")]
        public string PersonName { get; set; }

        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 3)]
        [Required(ErrorMessage = "请填写密码")]
        [DataType(DataType.Password)]
        [DisplayName("密码")]
        public string Password { get; set; }

        [Required(ErrorMessage = "请填写验证码")]
        [DisplayName("验证码")]
        public string ValidateCode { get; set; }

        [DisplayName("记住我?")]
        public bool RememberMe { get; set; }
    }
}
