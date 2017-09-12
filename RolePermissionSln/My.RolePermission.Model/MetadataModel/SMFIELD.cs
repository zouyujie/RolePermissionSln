/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Model.MetadataModel
 *文件名：  SMFIELD
 *版本号：  V1.0.0.0
 *唯一标识：499e6f5f-7d09-4778-84e5-72c82e026caa
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/26 7:50:01

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/26 7:50:01
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System;
using System.ComponentModel.DataAnnotations;

namespace My.RolePermission.Model
{
    [MetadataType(typeof(SysFieldMetadata))]//使用SysFieldMetadata对SysField进行数据验证
    public partial class SMFIELD
    {
        #region 自定义属性，即由数据实体扩展的实体

        [Display(Name = "父节点")]
        public string ParentIdOld { get; set; }

        #endregion
    }
    public class SysFieldMetadata
    {
        [ScaffoldColumn(false)]
        [Display(Name = "主键", Order = 1)]
        public int ID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "名称", Order = 2)]
        [Required(ErrorMessage = "不能为空")]
        [StringLength(50, ErrorMessage = "长度不可超过50")]
        public string MYTEXTS { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "父节点", Order = 3)]
        [StringLength(36, ErrorMessage = "长度不可超过36")]
        public string PARENTID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "表名", Order = 4)]
        [StringLength(50, ErrorMessage = "长度不可超过50")]
        public string MYTABLES { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "字段", Order = 5)]
        [StringLength(50, ErrorMessage = "长度不可超过50")]
        public string MYCOLUMS { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "排序", Order = 6)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? SORT { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "备注", Order = 7)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string REMARK { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建时间", Order = 8)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CREATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建人", Order = 9)]
        [StringLength(50, ErrorMessage = "长度不可超过50")]
        public string CREATEPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "编辑时间", Order = 10)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? UPDATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "编辑人", Order = 11)]
        [StringLength(50, ErrorMessage = "长度不可超过50")]
        public string UPDATEPERSON { get; set; }

    }
}
