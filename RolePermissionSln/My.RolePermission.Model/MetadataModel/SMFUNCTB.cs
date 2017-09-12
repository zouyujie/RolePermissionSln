/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Model.MetadataModel
 *文件名：  SMFUNCTB
 *版本号：  V1.0.0.0
 *唯一标识：9c45b414-fb65-4ac4-a851-72126212467a
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/7/16 17:16:17

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/7/16 17:16:17
 *修改人： zouqi
 *版本号： V1.0.0.0
 *描述：
 *
 *****************************************************************************/
using System.ComponentModel.DataAnnotations;

namespace My.RolePermission.Model
{
    [MetadataType(typeof(SysOperationMetadata))]//使用SysOperationMetadata对SMFUNCTB进行数据验证
    public partial class SMFUNCTB
    {
        [Display(Name = "菜单")]
        public string SysMenuId { get; set; }
    }
    public class SysOperationMetadata
    {
        [ScaffoldColumn(false)]
        [Display(Name = "主键", Order = 1)]
        public int FUNC_ID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "功能名称", Order = 2)]
        [StringLength(64, ErrorMessage = "长度不可超过64")]
        public object FUNC_NAME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "事件名", Order = 3)]
        [StringLength(256, ErrorMessage = "长度不可超过256")]
        public object EVENT_NAME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "图标", Order = 4)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public object ICONIC { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "显示顺序", Order = 5)]
        public int? ORDERCODE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "类名", Order = 6)]
        [StringLength(256, ErrorMessage = "长度不可超过256")]
        public object CLASS_NAME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "状态", Order = 7)]
        [StringLength(1, ErrorMessage = "长度不可超过1")]
        public object STATUS { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "功能分类", Order = 9)]
        [StringLength(10, ErrorMessage = "长度不可超过10")]
        public string SM_SYSTEM { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "功能编号", Order = 9)]
        [StringLength(32, ErrorMessage = "长度不可超过32")]
        public string FUNC_CODE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "父功能编号", Order = 9)]
        [StringLength(32, ErrorMessage = "长度不可超过32")]
        public string PARENTFUNC_CODE { get; set; }
    }
}
