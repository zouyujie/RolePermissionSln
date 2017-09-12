/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Model.MetadataModel
 *文件名：  SMMENUTB
 *版本号：  V1.0.0.0
 *唯一标识：356eefc2-4f79-4176-91df-d0738a878471
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/7/17 9:39:25

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/7/17 9:39:25
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
    [MetadataType(typeof(SysMenuMetadata))]
    public partial class SMMENUTB
    {
        #region 自定义属性，即由数据实体扩展的实体

        [Display(Name = "父模块")]
        public string ParentIdOld { get; set; }

        [Display(Name = "操作")]
        public string SysOperationId { get; set; }
        [Display(Name = "操作")]
        public string SysOperationIdOld { get; set; }

        #endregion
    }
    public class SysMenuMetadata
    {
        [ScaffoldColumn(false)]
        [Display(Name = "主键", Order = 1)]
        public int ID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "名称", Order = 2)]
        [Required(ErrorMessage = "不能为空")]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string NAME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "父模块", Order = 3)]
        public int PARENTID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "网址", Order = 4)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string URL { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "图标", Order = 5)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string ICONIC { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "排序", Order = 6)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? SORT { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "备注", Order = 7)]
        [StringLength(4000, ErrorMessage = "长度不可超过4000")]
        public string REMARK { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "状态", Order = 8)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string STATE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建人", Order = 9)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string CREATEPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建时间", Order = 10)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? CREATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "编辑时间", Order = 11)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? UPDATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "编辑人", Order = 12)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string UPDATEPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "叶子节点", Order = 9)]
        [StringLength(20, ErrorMessage = "长度不可超过20")]
        public string ISLEAF { get; set; }
    }
}
