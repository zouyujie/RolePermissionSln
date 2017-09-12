/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Model.ExtModel
 *文件名：  SMUSERTB
 *版本号：  V1.0.0.0
 *唯一标识：7d46c4f4-eacd-47cf-bdbf-84afc868787f
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/24 23:43:12

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/24 23:43:12
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My.RolePermission.Common.HtmlHelpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace My.RolePermission.Model
{
    [MetadataType(typeof(SMUSERTBMetadata))]//使用SMUSERTBMetadata对SMUSERTB进行数据验证
    public partial class SMUSERTB
    {
        [ScaffoldColumn(false)]
        [Display(Name = "角色")]
        public string SysRoleIdOld { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "创建人")]
        public string CreateUserName { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "更新人")]
        public string UpdateUserName { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "性别")]
        public string GenderName { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "状态")]
        public string StatusName { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "选择角色")]
        public string SysRoleId { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "确认密码", Order = 5)]
        [StringLength(20, ErrorMessage = "长度不可超过20")]
        [DataType(DataType.Password)]
        [Compare("U_PASSWORD", ErrorMessage = "两次密码不一致")]
        public string SurePassword { get; set; }

        public SMUSERTB ToPoCo()
        {
            return new SMUSERTB
            {
                USER_ID = this.USER_ID,
                U_ID = this.U_ID,
                USER_NAME = this.USER_NAME,
                StatusName = this.STATUS.GetStatusName(),
                GenderName = this.GENDER.GetGenderName(),
                CREATION_TIME = this.CREATION_TIME,
                CREATION_USER = this.CREATION_USER,
                CreateUserName = this.CreateUserName
            };
        }
        public Account ToAccount()
        {
            return new Account { USER_NAME = this.USER_NAME, UID = this.U_ID, USER_ID = this.USER_ID, RoleIds = this.SMROLETB.Select(x => x.ROLE_ID).ToList() };
        }
    }
    public class SMUSERTBMetadata
    {
        [ScaffoldColumn(false)]
        [Display(Name = "用户ID", Order = 1)]
        public int USER_ID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "用户登陆名", Order = 2)]
        [Required(ErrorMessage = "不能为空")]
        [StringLength(20, ErrorMessage = "长度不可超过20")]
        //[Remote("CheckName", "SysPerson", ErrorMessage = "用户名已经被占用,请改用其他用户名")]  //其中SysPerson是控制器的名称，CheckName是验证方法 
        public string U_ID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "姓名", Order = 3)]
        [StringLength(20, ErrorMessage = "长度不可超过20")]
        public string USER_NAME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "登陆密码", Order = 4)]
        [Required(ErrorMessage = "不能为空")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "长度不可小于3")]
        [DataType(DataType.Password)]
        public string U_PASSWORD { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "性别", Order = 6)]
        [StringLength(2, ErrorMessage = "长度不可超过2")]
        public string GENDER { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建时间", Order = 18)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? CREATION_TIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建人", Order = 19)]
        public int CREATION_USER { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "修改时间", Order = 20)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? UPDATE_TIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "修改人", Order = 21)]
        public int UPDATE_USER { get; set; }

        [Display(Name = "启用状态", Order = 3)]
        [Required(ErrorMessage = "不能为空")]
        public string STATUS { get; set; }
    }
    public class UserView : SMUSERTB
    {
        public List<string> RoleNames { get; set; }
    }
}
