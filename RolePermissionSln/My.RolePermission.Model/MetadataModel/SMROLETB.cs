/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Model.MetadataModel
 *文件名：  SMROLETB
 *版本号：  V1.0.0.0
 *唯一标识：de05f606-9ea1-4f4a-93a0-0139ee1354aa
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/25 18:30:19

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/25 18:30:19
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

namespace My.RolePermission.Model
{
    [MetadataType(typeof(SMROLETBMetadata))]
    public partial class SMROLETB
    {
        #region 自定义属性，即由数据实体扩展的实体

        [Display(Name = "人员")]
        [ScaffoldColumn(false)]
        public string SysPersonId { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "人员")]
        public string SysPersonIdOld { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "创建者")]
        public string CreateUserName { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "修改者")]
        public string UpdateUserName { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "状态")]
        public string StatusName { get; set; }

        [ScaffoldColumn(false)]
        public List<string> UserNames { get; set; }

        #endregion
    }
    public class SMROLETBMetadata
    {
        [ScaffoldColumn(false)]
        [Display(Name = "主键", Order = 1)]
        public int ROLE_ID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "角色名称", Order = 5)]
        [StringLength(20, ErrorMessage = "长度不可超过20")]
        [Required(ErrorMessage = "不能为空")]
        public string ROLE_NAME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建时间", Order = 4)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? CREATION_TIME { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "创建人", Order = 7)]
        public int CREATION_USER { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "说明", Order = 7)]
        [StringLength(100, ErrorMessage = "长度不可超过100")]
        public string REMARK { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "角色状态", Order = 7)]
        [StringLength(2, ErrorMessage = "长度不可超过200")]
        [Required(ErrorMessage = "不能为空")]
        public string STATUS { get; set; }
    }

    public class RoleView : SMROLETB
    {
        public List<string> UserNames { get; set; }
    }
}
