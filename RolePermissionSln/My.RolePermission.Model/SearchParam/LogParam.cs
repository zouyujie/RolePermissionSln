/****************************************************************************
 *Copyright (c) 2016 All Rights Reserved.
 *CLR版本： 4.0.30319.42000
 *机器名称：DESKTOP-V7CFIC3
 *公司名称：
 *命名空间：My.RolePermission.Model.SearchParam
 *文件名：  LogParam
 *版本号：  V1.0.0.0
 *唯一标识：c4c62a01-7f9b-4abd-a0e8-c45474375428
 *当前的用户域：DESKTOP-V7CFIC3
 *创建人：  zouqi
 *电子邮箱：zouyujie@126.com
 *创建时间：2016/6/26 6:44:08

 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2016/6/26 6:44:08
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
    public class LogParam : BaseParam
    {
        public string LOG_DATETIMEStart_Time { get; set; }
        public string LOG_DATETIMEEnd_Time { get; set; }
        public string OPERATION_TYPE { get; set; }
    }
}
