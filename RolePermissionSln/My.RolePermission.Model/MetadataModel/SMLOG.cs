/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Model.MetadataModel
 *文件名：  SMLOG
 *版本号：  V1.0.0.0
 *唯一标识：8ae8dca9-3256-4e40-af9d-112215c32e59
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/26 6:40:24

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/26 6:40:24
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
    [MetadataType(typeof(SMLOGMetadata))]//使用OMOPERATIONLOGTBMetadata对OMOPERATIONLOGTB进行数据验证
    public partial class SMLOG
    {
        #region 自定义属性，即由数据实体扩展的实体

        [ScaffoldColumn(false)]
        [Display(Name = "操作类型")]
        public string OperaterTypeName { get; set; }

        [Display(Name = "状态")]
        public string StatusName { get; set; }

        #endregion
    }
    public class SMLOGMetadata
    {
        [ScaffoldColumn(false)]
        [Display(Name = "日志ID", Order = 1)]
        public object LOG_ID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "操作时间", Order = 2)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime LOG_DATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "操作用户", Order = 3)]
        public object USER_ID { get; set; }

        //[ScaffoldColumn(true)]
        //[Display(Name = "登录IP", Order = 1)]
        //[StringLength(8, ErrorMessage = "长度不可超过8")]
        //public object LOG_IP { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "系统功能", Order = 4)]
        [StringLength(32, ErrorMessage = "长度不可超过32")]
        public object FUNC_CODE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "操作的类+函数名", Order = 5)]
        [StringLength(100, ErrorMessage = "长度不可超过100")]
        public object CLASSNAME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "操作类型", Order = 6)]
        public object OPERATION_TYPE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "操作描述", Order = 7)]
        [StringLength(4000, ErrorMessage = "长度不可超过4000")]
        public object REMARK { get; set; }
    }
}
